using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repos.Factories;
using Repos.Models;
using Lyngby_Bryghus.ViewModels;
using Lyngby_Bryghus.Helpers;
using Newtonsoft.Json.Linq;

namespace Lyngby_Bryghus.Controllers
{
    public class ProductController : Controller
    {
        ProductsFac PF = new ProductsFac();
        CategoryFac CF = new CategoryFac();
        PackageFac PaF = new PackageFac();
        SubscriptionFac SF = new SubscriptionFac();
        FileTool FT = new FileTool();

        // GET: Product
        public ActionResult Index()
        {
            ProductsView PV = new ProductsView
            {
                Products = PF.GetAllRealtion(),
                Categories = CF.GetAll(),
                json = JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json"))
            };

            return View(PV);
        }

        public ActionResult Details(int ID)
        {
            return View(PF.Get(ID));
        }


        public ActionResult Package()
        {
            return View(PaF.GetAllPakage());
        }

        public ActionResult Subscription()
        {
            return View(SF.GetAll());
        }

        public ActionResult Order()
        {
            return View(JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json")));
        }

    }
}