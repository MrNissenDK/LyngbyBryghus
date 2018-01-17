using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repos.Models;
using Duser;

namespace Repos.Factories
{
    public class ProductsFac : AutoFac<Products>
    {
        CategoryFac CF = new CategoryFac();
        ProductCategoryFac PCF = new ProductCategoryFac();
        public List<Products> GetPackOf(int amount)
        {
            string sql = "Select top " + amount + " * From Products WHERE COALESCE(Stock - (Select Sum(Amount) From OrderList Where ProductID = Products.ID), Stock) > 0 ORDER BY NEWID()";
            return ExecuteSQL<Products>(sql);
        }
        public List<RProducts> GetAllRealtion()
        {
            List<Products> ps = GetAll();
            List<RProducts> RPOut = new List<RProducts>();
            foreach (Products pd in ps)
            {
                List<ProductCategory> CategorysRelation = PCF.GetBy("ProductID", pd.ID);
                List<Category> Categorys = new List<Category>();
                foreach (ProductCategory cR in CategorysRelation)
                {
                    Categorys.Add(CF.Get(cR.CategoryID));
                }
                RProducts pOut = new RProducts
                {
                    categorys = Categorys

                };
                RPOut.Add((RProducts)Share.SetValue(pd, pOut));
            }
            return RPOut;
        }
        public RProducts GetRealtion(int ID)
        {
            Products p = Get(ID);
            List<ProductCategory> CategorysRelation = PCF.GetBy("ProductID", ID);
            List<Category> Categorys = new List<Category>();
            foreach (ProductCategory cR in CategorysRelation)
            {
                Categorys.Add(CF.Get(cR.CategoryID));
            }
            RProducts pOut = new RProducts
            {
                categorys = Categorys

            };
            return (RProducts)Share.SetValue(p, pOut);
        }
    }
}
