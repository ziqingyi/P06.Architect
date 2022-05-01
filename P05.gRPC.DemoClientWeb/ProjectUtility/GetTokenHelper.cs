using System.Collections.Generic;
using P03.DotNetCoreMVC.Utility.ApiHelper;
using P03.DotNetCoreMVC.Utility.Models;

namespace P05.gRPC.DemoClientWeb.ProjectUtility
{
    public class GetTokenHelper
    {

        public static JWTTokenResult GetToken()
        {

            string URI = "https://localhost:44396/api/Authentication/login";
            //string myParameters = "name=Admin&&password=123&&s=hs";

            Dictionary<string, string> pa = new Dictionary<string, string>();
            pa.Add("name", "Admin");
            pa.Add("password", "123");
            pa.Add("s", "hs");

            JWTTokenResult result = HttpClientHelper.GetJWTTokenWebClient(pa, URI);

            return result;
        }



    }
}
