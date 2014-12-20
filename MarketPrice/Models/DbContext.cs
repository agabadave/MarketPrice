using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketPrice.Models
{
    public class DbContext : System.Data.Entity.DbContext
    {

        public DbContext()
            : base("localDbConnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Market> Markets { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Commodity> Commodities { get; set; }

        public DbSet<VendorCommodity> VendorCommodities { get; set; } 
    }
}