using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using P03.DotNetCoreMVC.Utility.Models;

namespace P03.DotNetCoreMVC.Utility.WebHelper
{
    public static class CookieSessionHelper
    {
        public static void SetCookies(this HttpContext httpContext, string key, string value, int minutes = 30)
        {
            httpContext.Response.Cookies.Append(key,value,new CookieOptions()
            {
                Expires = DateAndTime.Now.AddMinutes(minutes)
            });
        }

        public static void DeleteCookies(this HttpContext httpContext, string key)
        {
            httpContext.Response.Cookies.Delete(key);
        }

        public static string GetCookiesValues(this HttpContext httpContext, string key)
        {
            httpContext.Request.Cookies.TryGetValue(key, out string value);
            return value;
        }


        public static CurrentUserCore GetCurrentUserBySession(this HttpContext context)
        {
            string sUser = context.Session.GetString("CurrentUser");
            if (sUser == null)
            {
                return null;
            }
            else
            {
                CurrentUserCore currentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentUserCore>(sUser);
                return currentUser;
            }
        }




    }
}
