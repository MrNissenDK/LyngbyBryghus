using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repos.Models;
using Newtonsoft.Json.Linq;


namespace Lyngby_Bryghus.ViewModels
{
    public class ProductsView
    {
        public List <RProducts> Products { get; set; }
        public List<Category> Categories { get; set; }
        public JObject json { get; set; }
    }
}