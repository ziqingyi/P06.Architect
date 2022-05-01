using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;


namespace P05.gRPC.DemoUserServer.Services
{
    public class UserService: User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserReply> FindUser(UserRequest request, ServerCallContext context)
        {
            Console.WriteLine("-----DemoUserServer, user service called...");
            return Task.FromResult(new UserReply
            {
                User = new UserReply.Types.UserModel()
                {
                    Id = request.Id,
                    Name = "Name" + new Random().Next(1, 1561) % 156,//index
                    Account = "useraccount_1",
                    Password = "pass123456"
                }
            });
        }


    }
}
