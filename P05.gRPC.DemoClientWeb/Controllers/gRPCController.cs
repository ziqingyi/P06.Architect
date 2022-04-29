using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using P05.gRPC.DemoServer;//server project 

namespace P05.gRPC.DemoClientWeb.Controllers
{
    public class gRPCController : Controller
    {
        private readonly ILogger<gRPCController> _logger;
        private readonly CustomMath.CustomMathClient _customMathClient;
        private readonly Course.CourseClient _courseClient;

        public gRPCController(ILogger<gRPCController> logger, 
            CustomMath.CustomMathClient customMathClient,
            Course.CourseClient courseClient)
        {
            _logger = logger;
            this._customMathClient = customMathClient;
            this._courseClient = courseClient;
        }

        public async Task<IActionResult> Index()
        {
            #region create channel in controller

            //using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            //{
            //    var client = new CustomMath.CustomMathClient(channel);

            //    System.Diagnostics.Debug.WriteLine("***************unary call************");
            //    {
            //        var reply = await client.SayHelloAsync(new HelloRequestMath { Name = "User1", Id = 10 });
            //        System.Diagnostics.Debug.WriteLine("Greeter reply : " + reply.Message);
            //    }
            //}

            #endregion

            #region test 

            Debug.WriteLine("-----------------unary call with Aop---------------------");
            {
                RequestPara requestPara = new RequestPara() { ILeft = 123, IRight = 234 };
                var replyPlus = await _customMathClient.PlusAsync(requestPara);
                Debug.WriteLine($"CustomMath {Thread.CurrentThread.ManagedThreadId}  reply result :{replyPlus.Result}  Massage={replyPlus.Message}");
                Debug.WriteLine("--------------------------------------");
            }
            {
                string URI = "https://localhost:44396/api/Authentication/login";
                string myParameters = "name=Admin&&password=123&&s=hs";
                jResult result;
                using (WebClient wcclient = new WebClient())
                {
                    wcclient.QueryString.Add("name", "Admin");
                    wcclient.QueryString.Add("password", "123");
                    wcclient.QueryString.Add("s", "hs");

                    var bytesValues = wcclient.UploadValues(URI,"POST",wcclient.QueryString);

                    var stringvalue = UnicodeEncoding.UTF8.GetString(bytesValues);

                    result= JsonConvert.DeserializeObject<jResult>(stringvalue);

                }

                string token = result?.token;

                var header = new Metadata { {"Authorization", $"Bearer {token}"} };
            

                var replyCourse = await this._courseClient.getCourseAsync(new CourseRequest() { Id = 123 }, headers:header   );
                Debug.WriteLine($"Course Client: {Thread.CurrentThread.ManagedThreadId}  reply result :{replyCourse.CourseInfo.Id + ". " + replyCourse.CourseInfo.Name + ". " + replyCourse.CourseInfo.Remark} ");
                Debug.WriteLine("--------------------------------------");
            }



            #endregion










            return View();
        }
    }


    public class jResult
    {
        public string result { get; set; }
        public string token { get; set; }
    }
}
