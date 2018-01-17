using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Image { get; set; }
    }
}
