using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MarketPrice.Models;
using DbContext = MarketPrice.Models.DbContext;

namespace MarketPrice.App_Start
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            //adding elements we wish to create by default

            //market places...
            var markets = new List<Market>()
            {
                new Market()
                {
                    Name = "Wandegeya",
                    Address = "Wadegya, Kampala Uganda"
                },

                new Market()
                {
                    Name = "Kamwokya",
                    Address = "Kamwokya, Nakawa Division, Kampala"
                },
                new Market()
                {
                    Name = "Ntinda",
                    Address = "Off Ntinda - Kisaasi Road,  Nakawa Division, Kampala"
                },
                new Market()
                {
                    Name = "Nakawa",
                    Address = "Jinja Road,  Nakawa Center"
                }
            };

            markets.ForEach(x => context.Markets.Add(x));


            //commodities..
            var commodities = new List<Commodity>()
            {
                new Commodity()
                {
                    Name = "Matooke",
                    Description = "Raw Boiled Bananas",
                    UnitOfSale = "Per Bunch"
                },
                new Commodity()
                {
                    Name = "Rice",
                    Description = "Pakistani Rice",
                    UnitOfSale = "Per Kg"
                },
                new Commodity()
                {
                    Name = "Sugar",
                    Description = "Kakira Sugar",
                    UnitOfSale = "Per Kg"
                }
            };

            commodities.ForEach(x => context.Commodities.Add(x));

            context.SaveChanges();
        }
    }
}