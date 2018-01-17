using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Models
{
    public class ROrders : Orders
    {
        public List<ROrderList> OrderDeatails { get; set; }
        public Package package { get; set; }
        public Customers customer { get; set; }
    }
}
