using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class ProductModelContext : DbContext
    {
        public ProductModelContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ShopBridgeDB.mdf;Integrated Security=True;User Instance=False")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
