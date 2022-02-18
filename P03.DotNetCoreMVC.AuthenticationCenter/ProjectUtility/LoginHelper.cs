using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.Utility.Models;
using P03.DotNetCoreMVC.Utility.WebHelper;
using P03.DotNetCoreMVC.Interface;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility
{
    public  class LoginHelper
    {

        private IUserService _userService = null;
        public LoginHelper(IUserService userService)
        {
            this._userService = userService;
        }

        #region user check methods

        /// <summary>
        /// Get user from database with same name, and use this user's information to check log in information.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[ChildActionOnly]
        public CurrentUserCore GetUser(string name)
        {

            var user =this._userService.Query<User>(u => u.Name ==name)
                .Select(u => new CurrentUserCore()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Account = u.Account,
                    Password = u.Password,
                    Email = u.Email,
                    State = u.State == 1 ? true : false,
                    Role = u.UserType == 1? "Admin": "Staff",
                    LastLoginTime = u.LastLoginTime ?? DateTime.Now,
                    CreateTime = u.CreateTime,
                    Datas = null
                }).FirstOrDefault();

            return user;
        }
        //[ChildActionOnly]
        public  bool CheckPass(CurrentUserCore user, string password)
        {
            return user.Password == password;
        }
        //[ChildActionOnly]
        public  bool CheckStatusActive(CurrentUserCore user)
        {
            return user.State == true;
        }

        #endregion



        #region Captcha Verification
        //[CustomAllowAnonymous]
        public  ActionResult CreateCaptchaFile(Controller controller)
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
        public  void CreateCaptchaResponse(Controller controller)
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
    }
}
