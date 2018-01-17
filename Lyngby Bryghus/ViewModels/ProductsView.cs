using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repos.Models;


namespace Lyngby_Bryghus.ViewModels
{
    public class ProductsView
    {
        public List <RProducts> Products { get; set; }
        public List<Category> Categories { get; set; }

    }
}