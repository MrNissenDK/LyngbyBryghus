using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repos.Factories;
using Repos.Models;
using System.Web.Helpers;
using System.Web.Security;
using System.IO;

namespace Lyngby_Bryghus.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserFac uf = new UserFac();
        ProductsFac pf = new ProductsFac();
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult LogInResult()
        {
            string Username = Request["Username"].Trim();
            string Password = Request["Password"].Trim();
            User a = uf.Login(Username, Password);

            if (a.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(a.ID.ToString(), false);
                Session["User"] = Username;
                Session["Role"] = a.Role;
                Session.Timeout = 20;
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

        public ActionResult addProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Products p)
        {
            if ((int)Session["Role"] >= 10)
            {
                pf.Insert(p);
            }
            return View();
        }
        public ActionResult updateProduct()
        {
            return View();
        }
        public ActionResult deletProduct(int ID)
        {
            if(Session["Role"] != null)
                if ((int)Session["Role"] >= 10)
                {
                    pf.Delete(ID);
                }
            return Redirect("/Product");
        }
    }
}