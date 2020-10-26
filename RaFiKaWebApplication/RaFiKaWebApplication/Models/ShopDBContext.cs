using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RaFiKaWebApplication.Models
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<ProductType> typesshoes { get; set; }
    }
}