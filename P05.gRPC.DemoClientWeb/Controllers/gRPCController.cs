using System;
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

        public gRPCController(ILogger<gRPCController> logger)
        {
            _logger = logger;


        }

        public async Task<IActionResult> Index()
        {

            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new CustomMath.CustomMathClient(channel);

                System.Diagnostics.Debug.WriteLine("***************one time call************");
                {
                    var reply = await client.SayHelloAsync(new HelloRequestMath { Name = "User1", Id = 10 });
                    System.Diagnostics.Debug.WriteLine("Greeter reply : " + reply.Message);
                }
            }

            return View();
        }
    }
}
