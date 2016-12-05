
using Kundbolaget.EntityFramework.Contexts;

namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Kundbolaget.Models.EntityModels;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            SeedSuppliers(context);
            SeedAlcoholLicenses(context);
            SeedCustomers(context);
        }

        private void SeedSuppliers(DataContext context)
        {
            Supplier[] suppliers =
            {
                new Supplier {Id = 1, Name = "Bengts Bärs", Email = "bengt@example.net"},
                new Supplier {Id = 2, Name = "Vlads Vodka", Email = "vlad@example.net"},
                new Supplier {Id = 3, Name = "Cissis Cider", Email = "cissi@example.net"},
                new Supplier {Id = 4, Name = "Pontus Punsch", Email = "pontus@example.net"},
                new Supplier {Id = 5, Name = "Håkans Hembränt", Email = "håkan@example.net"},
            };

            context.Suppliers.AddOrUpdate(suppliers);
        }

        private void SeedCustomers(DataContext context)
        {
            Customer[] customers =
            {
                new Customer
                {
                    Id = 10000, Name = "Ica", OrganizationNumber = 5560210261,
                    CreditLine = 150000, PaymentTerm = 30
                },
                new Customer
                {
                    Id = 10001, Name = "Coop",
                    CreditLine = 250000, PaymentTerm = 90
                },
                new Customer
                {
                    Id= 10002, Name = "Systembolaget",
                    CreditLine = 50000, PaymentTerm = 30
                }
            };

            context.Customers.AddOrUpdate(customers);
        }

        private void SeedAlcoholLicenses(DataContext context)
        {
            AlcoholLicense[] alcoholLicenses =
            {
                new AlcoholLicense {Id = 1, StartDate = DateTime.Today, EndDate = new DateTime(2020,12,24), IsValid = true},
                new AlcoholLicense {Id = 2, StartDate = DateTime.Today, EndDate = new DateTime(2021,12,24), IsValid = true},
                new AlcoholLicense {Id = 3, StartDate = DateTime.Today, EndDate = new DateTime(2022,12,24), IsValid = true}
            };

            context.AlcoholLicenses.AddOrUpdate(alcoholLicenses);
        }
    }
}
