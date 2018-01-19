using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repos.Factories;
using System.Web.Helpers;
using System.Web.Security;
using System.IO;

namespace Lyngby_Bryghus.Controllers
{
    public class UserController : Controller
    {
        UserFac uf = new UserFac();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult LogInResult()
        {
            string Username = Request["Username"].Trim();
            string Password = Crypto.Hash(Request["Password"].Trim());
            UserLogin a = af.LogIn(Username, Password);



            if (a.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(a.ID.ToString(), false);
                Session["User"] = Username;
                Session.Timeout = 2;
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }

                return View("Home");
            }
            else
            {
                ViewBag.msg = "Acces denied";
                return View("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}