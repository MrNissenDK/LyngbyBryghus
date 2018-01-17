using System;
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

            HomeView HV = new HomeView
            {
                Products = PF.GetPackOf(4),
                Events = EF.GetAll("Date", "DESC", 3),
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
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }


        public ActionResult update(string jPath, string value)
        {
            JObject json = JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json"));

            json.SelectToken(jPath).Replace(value);
            bool work = FT.SaveJson(json.ToString(), Request.PhysicalApplicationPath + "/ServerData/Pages.json");

            return Content(work.ToString());
        }

    }
}