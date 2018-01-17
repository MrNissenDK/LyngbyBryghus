using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lyngby_Bryghus.ViewModels;
using Repos.Factories;
using Repos.Models;

namespace Lyngby_Bryghus.Controllers
{
    public class HomeController : Controller
    {
        ProductsFac PF = new ProductsFac();
        EventFac EF = new EventFac();

        // GET: Home
        public ActionResult Index()
        {
            HomeView HV = new HomeView
            {
                Products = PF.GetPackOf(4),
                Events = EF.GetAll("Date", "DESC", 3)
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



    }
}