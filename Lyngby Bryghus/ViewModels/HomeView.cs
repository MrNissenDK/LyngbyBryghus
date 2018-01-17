using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repos.Models;


namespace Lyngby_Bryghus.ViewModels
{
    public class HomeView
    {
        public List<Products> Products { get; set; }
        public List<Event> Events { get; set; }
    }
}