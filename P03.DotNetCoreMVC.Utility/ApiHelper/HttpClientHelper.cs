using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.ApiHelper
{
    public static class HttpClientHelper
    {
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










    }
}
