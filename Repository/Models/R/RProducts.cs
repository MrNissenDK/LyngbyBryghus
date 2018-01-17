using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Models
{
    public class RProducts : Products
    {
        public List<Category> categorys {get; set;}
    }
}
