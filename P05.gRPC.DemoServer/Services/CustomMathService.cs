using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace P05.gRPC.DemoServer.Services
{
    public class CustomMathService : CustomMath.CustomMathBase
    {
        private readonly ILogger<CustomMathService> _logger;
        public CustomMathService(ILogger<CustomMathService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReplyMath> SayHello(HelloRequestMath request, ServerCallContext context)
        {
            Console.WriteLine("-----------CustomMathService.SayHello() service   " );
            return Task.FromResult<HelloReplyMath>(new HelloReplyMath()
            {
                Message = $"This is {request.Name} id: {request.Id}"
            });
        }


        public override Task<CountResult> Count(Empty request, ServerCallContext context)
        {
            Console.WriteLine("-----------CustomMathService.Count() service   " );
            return Task.FromResult(new CountResult()
            {
                Count = DateTime.Now.Year
            });
        }

        public override Task<ResponseResult> Plus(RequestPara request, ServerCallContext context)
        {
            Console.WriteLine("-----------CustomMathService.Plus() service   "   );
            int iResult = request.ILeft + request.IRight;
            ResponseResult responseResult = new ResponseResult()
            {
                Result = iResult,
                Message = "Success"
            };

            return Task.FromResult(responseResult);
        }


        public override async Task SelfIncreaseServer(IntArrayModel request, IServerStreamWriter<BathTheCatResp> responseStream, ServerCallContext context)
        {
            Console.WriteLine("-----------CustomMathService.SelfIncreaseServer() service   " );

            foreach (var item in request.Number)
            {
                int number = item;
                Console.WriteLine($"This is {number} invoke");
                await responseStream.WriteAsync(new BathTheCatResp() { Message = $"number++ ={++number}！" });
                await Task.Delay(500);
            }
        }

        public override async Task<IntArrayModel> SelfIncreaseClient(IAsyncStreamReader<BathTheCatReq> requestStream, ServerCallContext context)
        {
            Console.WriteLine("-----------CustomMathService.SelfIncreaseServer() service   " );

            IntArrayModel intArrayModel = new IntArrayModel();
            while (await requestStream.MoveNext())
            {
                intArrayModel.Number.Add(requestStream.Current.Id + 1);
                Console.WriteLine($"SelfIncreaseClient Number {requestStream.Current.Id} received and process..");
                Thread.Sleep(100);
            }
            return intArrayModel;
        }

        public override async Task SelfIncreaseDouble(IAsyncStreamReader<BathTheCatReq> requestStream, IServerStreamWriter<BathTheCatResp> responseStream, ServerCallContext context)
        {
            Console.WriteLine("-----------CustomMathService.SelfIncreaseDouble() service   " );

            while (await requestStream.MoveNext())
            {
                Console.WriteLine($"SelfIncreaseDouble Number {requestStream.Current.Id} received and process..");
                await responseStream.WriteAsync(new BathTheCatResp() { Message = $"number++ ={requestStream.Current.Id + 1}！" });
                await Task.Delay(500);
            }

        }




    }


}
