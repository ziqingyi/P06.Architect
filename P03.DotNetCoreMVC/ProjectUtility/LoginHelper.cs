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
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.Interface;
using P03.DotNetCoreMVC.Utility.Models;
using P03.DotNetCoreMVC.Utility.WebHelper;

namespace P03.DotNetCoreMVC.ProjectUtility
{
    public class LoginHelper
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
            //get user by IOC, this is Framework version
            //using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            //{
            //    User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name) || u.Account.Equals(name));
            //    return user;
            //}

            //get user from database 
            var user = this._userService.Query<User>(u => u.Name == name)
                .Select(u => new CurrentUserCore()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Account = u.Account,
                    Password = u.Password,
                    Email = u.Email,
                    State = u.State == 1 ? true : false,
                    Role = "",
                    LastLoginTime = u.LastLoginTime ?? DateTime.Now,
                    CreateTime = u.CreateTime,
                    Datas = null
                }).FirstOrDefault();

            return user;

        }
        //[ChildActionOnly]
        public bool CheckPass(CurrentUserCore user, string password)
        {
            return user.Password == password;
        }
        //[ChildActionOnly]
        public bool CheckStatusActive(CurrentUserCore user)
        {
            return user.State == true;
        }

        #endregion

        #region Captcha Verification
        //[CustomAllowAnonymous]
        public ActionResult CreateCaptchaFile(Controller controller)
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
        public void CreateCaptchaResponse(Controller controller)
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
