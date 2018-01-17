using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repos.Factories;
using Repos.Models;
using Lyngby_Bryghus.ViewModels;

namespace Lyngby_Bryghus.Controllers
{
    public class ProductController : Controller
    {
        ProductsFac PF = new ProductsFac();
        CategoryFac CF = new CategoryFac();
        PackageFac PaF = new PackageFac();
        SubscriptionFac SF = new SubscriptionFac();

        // GET: Product
        public ActionResult Index()
        {
            ProductsView PV = new ProductsView
            {
                Products = PF.GetAllRealtion(),
                Categories = CF.GetAll()
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
            return View();
        }

    }
}