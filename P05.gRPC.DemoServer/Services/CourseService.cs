using System.Threading.Tasks;
using Grpc.Core;

namespace P05.gRPC.DemoServer.Services
{
    public class CourseService : Course.CourseBase
    {

        public override Task<CourseReply> getCourse(CourseRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CourseReply()
            {
                CourseInfo = new CourseReply.Types.CourseModel()
                {
                    Id = request.Id,
                    Name = ".net introduction",
                    Remark = "introduction to .net"
                }
            });

        }

    }
}
