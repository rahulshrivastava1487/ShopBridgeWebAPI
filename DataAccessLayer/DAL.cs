using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static ShopBridgeDBEntities DbContext;

        static DAL()
        {
            DbContext = new ShopBridgeDBEntities();
        }

        public static List<Product> GetAllProducts()
        {
            return DbContext.Products.ToList();
        }

        public static Product GetProduct(int productId)
        {
            return DbContext.Products.Where(p => p.ProductID == productId).FirstOrDefault();
        }

        public static bool InsertProduct(Product productItem)
        {
            bool status;
            try
            {
                DbContext.Products.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool UpdateProduct(Product productItem)
        {
            bool status;

            try
            {
                Product prodItem = DbContext.Products.Where(p => p.ProductID == productItem.ProductID).FirstOrDefault();

                if (prodItem != null)
                {
                    prodItem.ProductName = productItem.ProductName;
                    prodItem.ProductDescription = productItem.ProductDescription;
                    prodItem.ProductQuantity = productItem.ProductQuantity;
                    prodItem.Price = productItem.Price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Product prodItem = DbContext.Products.Where(p => p.ProductID == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.Products.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
