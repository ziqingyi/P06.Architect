using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P05.gRPC.DemoServer;//server project 

namespace P05.gRPC.DemoClientWeb.Controllers
{
    public class gRPCController : Controller
    {
        private readonly ILogger<gRPCController> _logger;
        private readonly CustomMath.CustomMathClient _customMathClient;

        public gRPCController(ILogger<gRPCController> logger, CustomMath.CustomMathClient customMathClient)
        {
            _logger = logger;
            this._customMathClient = customMathClient;

        }

        public async Task<IActionResult> Index()
        {
            #region create channel in controller

            //using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            //{
            //    var client = new CustomMath.CustomMathClient(channel);

            //    System.Diagnostics.Debug.WriteLine("***************one time call************");
            //    {
            //        var reply = await client.SayHelloAsync(new HelloRequestMath { Name = "User1", Id = 10 });
            //        System.Diagnostics.Debug.WriteLine("Greeter reply : " + reply.Message);
            //    }
            //}

            #endregion

            #region streaming

            System.Diagnostics.Debug.WriteLine("--------------client streaming , multiple -> one response---------------------------");
            {
                var bathCat = _customMathClient.SelfIncreaseClient();
                for (int i = 0; i < 10; i++)
                {
                    int tempId = new Random().Next(0, 20);
                    await bathCat.RequestStream.WriteAsync(new BathTheCatReq() { Id = tempId });
                    await Task.Delay(100);
                    System.Diagnostics.Debug.WriteLine($"{DateTime.Now} This is {i} Request with id {tempId} on thread {Thread.CurrentThread.ManagedThreadId}");
                }
                System.Diagnostics.Debug.WriteLine("--------------------------------------");

                await bathCat.RequestStream.CompleteAsync();
                System.Diagnostics.Debug.WriteLine("all id are sent" + DateTime.Now);
                System.Diagnostics.Debug.WriteLine("receive result: ");

                foreach (var item in bathCat.ResponseAsync.Result.Number)
                {
                    System.Diagnostics.Debug.WriteLine($"{DateTime.Now} This is response item: {item} Result");
                }
                System.Diagnostics.Debug.WriteLine("--------------------------------------");
            }

            #endregion










            return View();
        }
    }
}
