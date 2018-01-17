using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repos.Models;
using Duser;

namespace Repos.Factories
{
    public class PackageFac : AutoFac<Package>
    {
        public List<Package> GetAllPakage()
        {
            return ExecuteSQL<Package>("SELECT * FROM Package WHERE ID>0");
        }
    }
}
