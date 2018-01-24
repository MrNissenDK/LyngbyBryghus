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
using Lyngby_Bryghus.Helpers;

namespace Lyngby_Bryghus.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserFac uf = new UserFac();
        ProductsFac pf = new ProductsFac();
        FileTool FT = new FileTool();
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Session["user"] != null)
                return Redirect("/user/ControlPanle");
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
                Session["ID"] = a.ID;
                Session["User"] = a.Name;
                Session["Role"] = a.Role;
                Session.Timeout = 20;
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }

                return Redirect("/user/ControlPanle");
            }
            else
            {
                ViewBag.msg = "Acces denied";
                return View("Index");
            }
        }

        public ActionResult ControlPanle()
        {
            return View("Home");
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
        public ActionResult addProduct(HttpPostedFileBase file,Products p)
        {

            if (Session["Role"] != null)
                if ((int)Session["Role"] >= 10)
                {
                    p.Price = Decimal.Parse(Request["Price"].Replace(".", ","));
                    p.Stock = Decimal.Parse(Request["Stock"].Replace(".", ","));
                    if(p.Description != null)
                        p.Description = p.Description.Replace("\r\n", "<br/>");
                    if (p.Details != null)
                        p.Details = p.Details.Replace("\r\n", "<br/>");
                    if (p.Info != null)
                        p.Info = p.Info.Replace("\r\n", "<br/>");
                    string name = p.Name;

                    p.Image = FT.Fileupload(file, name, Request.PhysicalApplicationPath+ "Images/ProductAllImages/Small/", new string[] { "jpg","png","jpeg", "gif" });

                    pf.Insert(p);
                }
            return Redirect("/Product/Index/");
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
                    Products p = pf.Get(ID);
                    if(FT.deleteFile(Request.PhysicalApplicationPath + "Images/ProductAllImages/Small/"+p.Image))
                        pf.Delete(ID);
                }
            return Redirect("/Product");
        }

        public ActionResult addEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addEvent(Event e)
        {
            return View();
        }
    }
}