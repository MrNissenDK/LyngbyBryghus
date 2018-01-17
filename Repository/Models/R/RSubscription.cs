using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Models
{
    public class RSubscription
    {
        public Customers customer { get; set; }
        public Subscription subscription { get; set; }
    }
}
