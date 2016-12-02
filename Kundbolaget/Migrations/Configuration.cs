
using Kundbolaget.EntityFramework.Contexts;

namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Kundbolaget.Models.EntityModels;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kundbolaget.EntityFramework.Contexts.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kundbolaget.EntityFramework.Contexts.DataContext context)
        {
            SeedAlcoholLicenses(context);

            Supplier[] suppliers =
            {
                new Supplier { Id = 1, Name = "Bengts Bärs", Email = "bengt@example.net" },
                new Supplier { Id = 2, Name = "Vlads Vodka", Email = "vlad@example.net" },
                new Supplier { Id = 3, Name = "Cissis Cider", Email = "cissi@example.net" },
                new Supplier { Id = 4, Name = "Pontus Punsch", Email = "pontus@example.net" },
                new Supplier { Id = 5, Name = "Håkans Hembränt", Email = "håkan@example.net" },
            };

            context.Suppliers.AddOrUpdate(suppliers);
        }

        private void SeedAlcoholLicenses(DataContext context)
        {
            AlcoholLicense[] alcoholLicenses =
            {
                new AlcoholLicense {StartDate = DateTime.Today, EndDate = new DateTime(2020,12,24), IsValid = true},
                new AlcoholLicense {StartDate = DateTime.Today, EndDate = new DateTime(2021,12,24), IsValid = true},
                new AlcoholLicense {StartDate = DateTime.Today, EndDate = new DateTime(2022,12,24), IsValid = true}
            };

            context.AlcoholLicenses.AddOrUpdate(alcoholLicenses);
        }
    }
}
