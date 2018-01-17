using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using Repos.Models;

namespace Repos.Factories
{
    public class SubscriptionFac : AutoFac<Subscription>
    {
        CustomerFac CF = new CustomerFac();
        CustomerSubFac CSF = new CustomerSubFac();
        public List<Products> GetPackOf(int amount)
        {
            string sql = "Select top " + amount + " * From Products WHERE COALESCE(Stock - (Select Sum(Amount) From OrderList Where ProductID = Products.ID), Stock) > 0 ORDER BY NEWID()";
            return ExecuteSQL<Products>(sql);
        }
        public List<RSubscription> GetAllRealtion()
        {
            List<CustomerSub> CS = CSF.GetAll();
            List<RSubscription> RO = new List<RSubscription>();
            foreach (CustomerSub cs in CS)
            {
                Customers cus = CF.Get(cs.CustumerID);
                Subscription sub = Get(cs.subscriptionID);

                RSubscription subscription = new RSubscription
                {
                    customer = cus,
                    subscription = sub
                };
                RO.Add((RSubscription)Share.SetValue(cs, subscription));
            }
            return RO;
        }
        public List<RSubscription> GetRealtionBy(string column, string value, string ordercolumn = "ID", string direction = "DESC")
        {
            List<CustomerSub> CS = CSF.GetBy(column,value,ordercolumn,direction);
            List<RSubscription> RO = new List<RSubscription>();
            foreach (CustomerSub cs in CS)
            {
                Customers cus = CF.Get(cs.CustumerID);
                Subscription sub = Get(cs.subscriptionID);

                RSubscription subscription = new RSubscription
                {
                    customer = cus,
                    subscription = sub
                };
                RO.Add((RSubscription)Share.SetValue(cs, subscription));
            }
            return RO;
        }
        public RSubscription GetRealtion(int ID)
        {
            CustomerSub CS = CSF.Get(ID);
            Customers cus = CF.Get(CS.CustumerID);
            Subscription sub = Get(CS.subscriptionID);

            RSubscription subscription = new RSubscription
            {
                customer = cus,
                subscription = sub
            };
            return (RSubscription)Share.SetValue(CS, subscription);
        }
    }
}
