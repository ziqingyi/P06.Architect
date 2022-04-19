﻿// See https://aka.ms/new-console-template for more information


using Grpc.Net.Client;
using P05.gRPC.DemoServer;

Console.WriteLine("Hello, World!");

TestHello().Wait();

static async Task TestHello()
{
        using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
        {
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "User1" });
            Console.WriteLine("Greeter reply : " + reply.Message);

            //client.SayHello(new HelloRequest { Name = "Eleven" });
        }


}





