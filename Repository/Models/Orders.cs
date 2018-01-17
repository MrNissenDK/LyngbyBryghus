using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int CustomersID { get; set; }
        public DateTime Date { get; set; }
        public int PackageID { get; set; }
    }
}
