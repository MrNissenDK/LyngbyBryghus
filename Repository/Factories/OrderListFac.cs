using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using Repos.Models;

namespace Repos.Factories
{
    public class OrderListFac : AutoFac<OrderList>
    {
        CategoryFac CF = new CategoryFac();
        ProductsFac PF = new ProductsFac();
        public List<Products> GetPackOf(int amount)
        {
            string sql = "Select top " + amount + " * From Products WHERE COALESCE(Stock - (Select Sum(Amount) From OrderList Where ProductID = Products.ID), Stock) > 0 ORDER BY NEWID()";
            return ExecuteSQL<Products>(sql);
        }
        public List<ROrderList> GetAllRealtion()
        {
            List<OrderList> ps = GetAll();
            List<ROrderList> oLOut = new List<ROrderList>();
            foreach (OrderList oL in ps)
            {
                RProducts Products = PF.GetRealtion(oL.ProductID);
                ROrderList rOL = new ROrderList {
                    product = Products
                };
                oLOut.Add((ROrderList)Share.SetValue(oL, rOL));
            }
            return oLOut;
        }
        public List<ROrderList> GetRealtionBy(string column, string value, string ordercolumn = "ID", string direction = "DESC")
        {
            List<OrderList> ps = GetBy(column,value,ordercolumn,direction);
            List<ROrderList> oLOut = new List<ROrderList>();
            foreach (OrderList oL in ps)
            {
                RProducts Products = PF.GetRealtion(oL.ProductID);
                ROrderList rOL = new ROrderList
                {
                    product = Products
                };
                oLOut.Add((ROrderList)Share.SetValue(oL, rOL));
            }
            return oLOut;
        }
        public ROrderList GetRealtion(int ID)
        {
            OrderList oL = Get(ID);
            RProducts rP = PF.GetRealtion(oL.ProductID);
            ROrderList olOut = new ROrderList {
                product = rP
            };
            return (ROrderList)Share.SetValue(oL, olOut);
        }
    }
}
