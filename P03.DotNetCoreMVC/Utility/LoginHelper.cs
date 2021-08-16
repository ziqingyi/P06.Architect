using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P03.DotNetCoreMVC.EntityFrameworkModels;
using P03.DotNetCoreMVC.Utility.Models;
using P03.DotNetCoreMVC.Utility.WebHelper;

namespace P03.DotNetCoreMVC.Utility
{
    public static class LoginHelper
    {
        #region Captcha Verification
        //[CustomAllowAnonymous]
        public static ActionResult CreateCaptchaFile(Controller controller)
        {
            string code = "";
            Bitmap bitmap = CaptchaHelper.CreateCaptchaObject(out code);

            //base.HttpContext.Session["CheckCode"] = code;//mvc session is used for identify the user
            controller.HttpContext.Session.SetString("CheckCode", code);

            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return controller.File(stream.ToArray(), "image/gif");//return FileContentResult picture
        }
        //[CustomAllowAnonymous]
        public static void CreateCaptchaResponse(Controller controller)
        {
            string code = "";
            Bitmap bitmap = CaptchaHelper.CreateCaptchaObject(out code);
            {
                //base.HttpContext.Session["CheckCode"] = code;//mvc
                //bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);//mvc
            }

            controller.HttpContext.Session.SetString("CheckCode", code);
            //bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);

            controller.Response.ContentType = "image/gif";
        }
        #endregion




        #region user check methods

        /// <summary>
        /// Get user from database with same name, and use this user's information to check log in information.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[ChildActionOnly]
        public static TempDatabaseUser GetUser(string name)
        {
            //get user by IOC, this is Framework version
            //using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            //{
            //    User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name) || u.Account.Equals(name));
            //    return user;
            //}

           


            //get user from database 
            return new TempDatabaseUser()
            {
                Id = 1,
                Name = "User1",
                Account = "Administrator",
                Password = "123456",
                Email = "werqfasdf@gmail.com",
                Role = "Admin",
                LastLoginTime = DateTime.Now,
                State = 1
            };

        }
        //[ChildActionOnly]
        public static bool CheckPass(TempDatabaseUser user, string password)
        {
            return user.Password == password;
        }
        //[ChildActionOnly]
        public static bool CheckStatusActive(TempDatabaseUser user)
        {
            return user.State == 1;
        }

        #endregion


    }
}
