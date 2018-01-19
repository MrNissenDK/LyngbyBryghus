using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repos.Factories;
using Repos.Models;
using Lyngby_Bryghus.ViewModels;
using Newtonsoft.Json.Linq;
using Lyngby_Bryghus.Helpers;
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
            PackageView PaV = new PackageView
            {
                Packages = PaF.GetAllPakage(),
                json = JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json"))

            };
            return View(PaV);
        }

        public ActionResult Subscription()
        {
            SubscriptionView SuV = new SubscriptionView
            {
                Subscriptions = SF.GetAll(),
                json = JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json"))

            };

            return View(SuV);
        }

        public ActionResult Order()
        {
            return View(JObject.Parse(FT.LoadFile(Request.PhysicalApplicationPath + "/ServerData/Pages.json")));
        }

    }
}