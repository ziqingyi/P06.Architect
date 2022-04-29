using System;
using System.Diagnostics;
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
                RequestPara requestPara = new RequestPara() { ILeft = 123, IRight = 234 };
                var replyPlus = await _customMathClient.PlusAsync(requestPara);
                Debug.WriteLine($"CustomMath {Thread.CurrentThread.ManagedThreadId}  reply result :{replyPlus.Result}  Massage={replyPlus.Message}");
                Debug.WriteLine("--------------------------------------");
            }

            #endregion










            return View();
        }
    }
}
