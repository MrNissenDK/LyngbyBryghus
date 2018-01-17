using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using Repos.Models;

namespace Repos.Factories
{
    public class OrderFac : AutoFac<Orders>
    {

        CustomerFac CF = new CustomerFac();
        OrderListFac OLF = new OrderListFac();
        PackageFac PF = new PackageFac();
        public List<Products> GetPackOf(int amount)
        {
            string sql = "Select top " + amount + " * From Products WHERE COALESCE(Stock - (Select Sum(Amount) From OrderList Where ProductID = Products.ID), Stock) > 0 ORDER BY NEWID()";
            return ExecuteSQL<Products>(sql);
        }
        public List<ROrders> GetAllRealtion()
        {
            List<Orders> OR = GetAll();
            List<ROrders> RO = new List<ROrders>();
            foreach (Orders O in OR)
            {
                List<ROrderList> OrdList = OLF.GetRealtionBy("OrderID", O.ID.ToString());
                Customers cus = CF.Get(O.CustomersID);
                Package pac = PF.Get(O.PackageID);

                ROrders OOur = new ROrders
                {
                    OrderDeatails = OrdList,
                    package = pac
                };
                RO.Add((ROrders)Share.SetValue(O, OOur));
            }
            return RO;
        }
        public List<ROrders> GetRealtionBy(string column, string value, string ordercolumn = "ID", string direction = "DESC")
        {
            List<Orders> OR = GetBy(column,value,ordercolumn,direction);
            List<ROrders> RO = new List<ROrders>();
            foreach (Orders O in OR)
            {
                List<ROrderList> OrdList = OLF.GetRealtionBy("OrderID", O.ID.ToString());
                Customers cus = CF.Get(O.CustomersID);
                Package pac = PF.Get(O.PackageID);

                ROrders OOur = new ROrders
                {
                    OrderDeatails = OrdList,
                    package = pac
                };
                RO.Add((ROrders)Share.SetValue(O, OOur));
            }
            return RO;
        }
        public ROrders GetRealtion(int ID)
        {
            Orders O = Get(ID);
            List<ROrderList> OrdList = OLF.GetRealtionBy("OrderID", ID.ToString());
            Customers cus = CF.Get(O.CustomersID);
            Package pac = PF.Get(O.PackageID);

            ROrders OOur = new ROrders
            {
                OrderDeatails = OrdList,
                package = pac
            };
            return (ROrders)Share.SetValue(O, OOur);
        }
    }
}
