using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using P03.DotNetCoreMVC.Utility.WebHelper;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using P03.DotNetCoreMVC.Utility.Extensions;
using P03.DotNetCoreMVC.Utility.Filters;
using P03.DotNetCoreMVC.Utility.Models;

namespace P03.DotNetCoreMVC.Controllers
{
   
    public class DFourthController : Controller
    {



        [TypeFilter(typeof(CustomActionCheckFilterAttribute))]
        public IActionResult Index()
        {
            return View();
        }

        #region Login and log out


        



        //by pass authorize if authorize is configured globally or whole controller. 
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password,string captcha)
        {
            string formName = base.HttpContext.Request.Form["Name"];


            LoginResult result = base.HttpContext.Login(name, password, captcha, GetUser, CheckPass, CheckStatusActive);

            if (result == LoginResult.Success)
            {

                return base.Redirect("/DFourth/Index");

            }
            else
            {
                return View();
            }


        }
        public ActionResult Logout()
        {
            base.HttpContext.SignOutAsync().Wait();
            return this.Redirect("~/DFourth/Login");
        }

        #endregion
    










        #region Captcha Verification
        //[CustomAllowAnonymous]
        public ActionResult CreateCaptchaFile()
        {
            string code = "";
            Bitmap bitmap = CaptchaHelper.CreateCaptchaObject(out code);

            //base.HttpContext.Session["CheckCode"] = code;//mvc session is used for identify the user
            base.HttpContext.Session.SetString("CheckCode", code);

            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//return FileContentResult picture
        }
        //[CustomAllowAnonymous]
        public void CreateCaptchaResponse()
        {
            string code = "";
            Bitmap bitmap = CaptchaHelper.CreateCaptchaObject(out code);
            { 
                //base.HttpContext.Session["CheckCode"] = code;//mvc
                //bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);//mvc
            }

            base.HttpContext.Session.SetString("CheckCode", code);
            //bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);

            base.Response.ContentType = "image/gif";
        }
        #endregion




        #region user check methods

        /// <summary>
        /// Get user from database with same name, and use this user's information to check log in information.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[ChildActionOnly]
        public TempDatabaseUser GetUser(string name)
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
        public bool CheckPass(TempDatabaseUser user, string password)
        {
            return user.Password == password;
        }
        //[ChildActionOnly]
        public bool CheckStatusActive(TempDatabaseUser user)
        {
            return user.State == 1;
        }

        #endregion






    }
}
