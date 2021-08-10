using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using P03.DotNetCoreMVC.Utility.WebHelper;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;

namespace P03.DotNetCoreMVC.Controllers
{
    public class DFourthController : Controller
    {







        public IActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string name, string password, string verify)
        {


            return View();
        }











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
            //bitmap.Save(base.Response.co, ImageFormat.Gif);

            base.Response.ContentType = "image/gif";
        }
        #endregion







    }
}
