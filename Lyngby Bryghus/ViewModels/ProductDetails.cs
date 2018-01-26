using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lyngby_Bryghus.ViewModels
{
    public class ProductDetails
    {
        public int Next { get; set; }
        public Repos.Models.Products product { get; set; }
    }
}