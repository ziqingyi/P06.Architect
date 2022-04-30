using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using P03.DotNetCoreMVC.Utility.Models;

namespace P03.DotNetCoreMVC.Utility.ApiHelper
{
    public static class HttpClientHelper
    {

        #region Get Request
        public static string InvokeApi(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri(url);

                var result = httpClient.SendAsync(message).Result;
                string context = result.Content.ReadAsStringAsync().Result;
                return context;
            }
        }

        #endregion


        #region Post request WebClient

        public static JWTTokenResult GetJWTTokenWebClient(Dictionary<string, string> dic, string uri)
        {
            using (WebClient wcclient = new WebClient())
            {
                foreach (var item in dic)
                {
                    wcclient.QueryString.Add(item.Key, item.Value);
                }

                var bytesValues = wcclient.UploadValues(uri, "POST", wcclient.QueryString);

                var stringvalue = UnicodeEncoding.UTF8.GetString(bytesValues);

                var  result = JsonConvert.DeserializeObject<JWTTokenResult>(stringvalue);
                return result;

            }
        }

        #endregion





        #region Post request HttpClient and WebRequest not tested

        public async static Task<string> GetJWTTokenHttpClient(Dictionary<string, string> dic, string url)
        {
            string result = await PostClient(dic,url);


            return JsonConvert.DeserializeObject<JWTTokenResult>(result).token;
        }


        private async static Task<string> PostClient(Dictionary<string, string> dic, string url)
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"Name","xxx" },
            //    {"Password","xx" }
            //};
            
            var json = JsonConvert.SerializeObject(dic);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClientHandler handler = new HttpClientHandler();
            using (var httpClient = new HttpClient(handler))
            {
                var content = new FormUrlEncodedContent(dic);

                var respose = await httpClient.PostAsync(url, data);

                Debug.Print(respose.StatusCode.ToString());

                return await respose.Content.ReadAsStringAsync();
            }

        }


        /// <summary>
        /// HttpWebRequest
        /// </summary>
        private async static Task<string> PostWebQuest(Dictionary<string, string> dic, string url)
        {
            //var user = new
            //{
            //    Name = "",
            //    Password = ""
            //};
           
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(dic);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "POST";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    return await reader.ReadToEndAsync();
                }
                else
                {
                    throw new Exception($"Exception {res.StatusCode}");
                }
            }
        }



        #endregion


















    }






}
