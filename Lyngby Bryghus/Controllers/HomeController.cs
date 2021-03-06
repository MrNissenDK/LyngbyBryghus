﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lyngby_Bryghus.ViewModels;
using Repos.Factories;
using Repos.Models;
using Newtonsoft.Json;
using Lyngby_Bryghus.Helpers;
using Newtonsoft.Json.Linq;
using Lyngby_Bryghus.ViewFactories;

namespace Lyngby_Bryghus.Controllers
{
    public class HomeController : Controller
    {
        ProductsFac PF = new ProductsFac();
        EventFac EF = new EventFac();
        FileTool FT = new FileTool();

        // GET: Home
        public ActionResult Index()
        {
            EF.ExecuteSQL("Delete Event where Date < '"+DateTime.Now.ToString("yyyy-MM-dd")+"'");
            HomeView HV = new HomeView
            {
                Products = PF.GetPackOf(4),
                Events = EF.GetAll("Date", "ASC"),
                json = JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json"))
            };
            return View(HV);
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View(JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json")));
        }

        
        public ActionResult SendMail(string businessName, string name, string email, string phoneNumber, string message)
        {
            //Mailer mailer = new Mailer();
            //mailer.Send(businessName, name, email, phoneNumber, message);

            ViewBag.MSG = "Mailen er sendt!!!";


            return Json(ViewBag.MSG, JsonRequestBehavior.DenyGet);
        }


        public ActionResult Details()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult update(string jPath, string value)
        {
            JObject json = JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json"));

            json.SelectToken(jPath).Replace(value);
            bool work = FT.SaveJson(json.ToString(), Request.PhysicalApplicationPath + "/ServerData/Pages.json");

            return Redirect(Request.UrlReferrer.ToString());
        }



        //Child action
        public ActionResult Footer()
        {
            return View(JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json")));
        }

    }
}