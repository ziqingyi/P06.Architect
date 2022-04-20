using System.Threading.Tasks;
using Grpc.Core;

namespace P05.gRPC.DemoServer.Services
{
    public class CustomMathService:CustomMath.CustomMathBase
    {
        public override Task<HelloReplyMath> SayHello(HelloRequestMath request, ServerCallContext context)
        {
            return Task.FromResult<HelloReplyMath>(new HelloReplyMath()
            {
                Message = $"This is {request.Name} id: {request.Id}"
            });
        }

    }


}
