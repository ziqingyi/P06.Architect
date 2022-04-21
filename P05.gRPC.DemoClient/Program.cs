// See https://aka.ms/new-console-template for more information


using System.Text.Json.Serialization;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using P05.gRPC.DemoServer;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

TestMath().Wait();

static async Task TestHello()
{
        using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
        {
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "User1" });
            Console.WriteLine("Greeter reply : " + reply.Message);

            client.SayHello(new HelloRequest { Name = "User2" });
        }
}


static async Task TestMath()
{
    #region token
    string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRWxldmVuIiwiRU1haWwiOiI1NzI2NTE3N0BxcS5jb20iLCJBY2NvdW50IjoieHV5YW5nQHpoYW94aUVkdS5OZXQiLCJBZ2UiOiIzMyIsIklkIjoiMTIzIiwiTW9iaWxlIjoiMTg2NjQ4NzY2NzEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIlNleCI6IjEiLCJuYmYiOjE1OTA1OTQ1OTEsImV4cCI6MTU5MDU5ODEzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1NzI2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1NzI2In0.MGXKLQ9ZVh0xvsQ1kNhb5gXi_8hqD2RL8metxhjEFiU";
    var headers = new Metadata { { "Authorization", $"Bearer {token}" } };
    #endregion
     
    using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
    {
        var client = new CustomMath.CustomMathClient(channel);

        Console.WriteLine("***************one time call************");
        {
            var reply = await client.SayHelloAsync(new HelloRequestMath { Name = "User1", Id = 10 });
            Console.WriteLine("Greeter reply : " + reply.Message);
        }

        Console.WriteLine("***********************call once async********************************");
        {
            RequestPara requestPara = new RequestPara() { ILeft = 123, IRight = 234 };
            var replyPlus = await client.PlusAsync(requestPara);
            Console.WriteLine($"CustomMath {Thread.CurrentThread.ManagedThreadId}  reply result :{replyPlus.Result}  Massage={replyPlus.Message}");
        }
        Console.WriteLine("***********************sync********************************");
        {
            var replyPlusSync = client.Plus(new RequestPara() { ILeft = 123, IRight = 234 });
            Console.WriteLine($"CustomMath {Thread.CurrentThread.ManagedThreadId}   reply result :{replyPlusSync.Result}  Massage={replyPlusSync.Message}");
        }
        Console.WriteLine("***********************async with Token********************************");
        {
            RequestPara requestPara = new RequestPara() { ILeft = 123, IRight = 234 };

            var replyPlus = await client.PlusAsync(requestPara, headers);
            Console.WriteLine($"CustomMath {Thread.CurrentThread.ManagedThreadId}   reply result :{replyPlus.Result}  Massage={replyPlus.Message}");
        }

        Console.WriteLine("***********************sync with Token********************************");
        {
            RequestPara requestPara = new RequestPara() { ILeft = 123, IRight = 234 };
            var replyPlusSync = client.Plus(requestPara, headers);
            Console.WriteLine($"CustomMath {Thread.CurrentThread.ManagedThreadId}   reply result :{replyPlusSync.Result}  Massage={replyPlusSync.Message}");
        }

        Console.WriteLine("**************************empty request*****************************");
        {
            var countResult = await client.CountAsync(new Empty());
            Console.WriteLine($"random {countResult.Count}");
            var rand = new Random(DateTime.Now.Millisecond);
        }
        Console.WriteLine("**************************client flow *****************************");
        {
            var bathCat = client.SelfIncreaseClient();
            for (int i = 0; i < 10; i++)
            {
                await bathCat.RequestStream.WriteAsync(new BathTheCatReq() { Id = new Random().Next(0, 20) });
                await Task.Delay(100);
                Console.WriteLine($"This is {i} Request {Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine("**********************************");
            
            await bathCat.RequestStream.CompleteAsync();
            Console.WriteLine("sent 10 id");
            Console.WriteLine("receive result: ");

            foreach (var item in bathCat.ResponseAsync.Result.Number)
            {
                Console.WriteLine($"This is {item} Result");
            }
            Console.WriteLine("**********************************");
        }
        Console.WriteLine("**************************Server side flow *****************************");
        {
            IntArrayModel intArrayModel = new IntArrayModel();
            for (int i = 0; i < 15; i++)
            {
                intArrayModel.Number.Add(i);//cannot assign value directly to Number
            }

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5.5)); //cancel after 5.5s
            var bathCat = client.SelfIncreaseServer(intArrayModel, cancellationToken: cts.Token);

            //var bathCat = client.SelfIncreaseServer(intArrayModel);//no cancel token
            var bathCatRespTask = Task.Run(async () =>
            {
                await foreach (var resp in bathCat.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine(resp.Message);
                    Console.WriteLine($"This is  Response {Thread.CurrentThread.ManagedThreadId}");
                    Console.WriteLine("**********************************");
                }
            });
            Console.WriteLine("客户端已发送完10个id");
            //start receiving  response
            await bathCatRespTask;
        }







    }






}










