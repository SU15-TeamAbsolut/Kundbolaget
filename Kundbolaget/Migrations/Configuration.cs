
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
            SeedCountries(context);
            SeedAddresses(context);

            SeedSuppliers(context);
            SeedCustomers(context);
            SeedAlcoholLicenses(context);
        }

        private void SeedCountries(DataContext context)
        {
            Country[] countries =
            {
                new Country { Id = 1, Name = "Sverige", CountryCode = "SE" }
            };

            context.Countries.AddOrUpdate(countries);
        }

        private void SeedAddresses(DataContext context)
        {
            // Fetch Sweden
            var country = context.Countries.Find(1);

            Address[] addresses =
            {
                new Address { Id = 1, Street = "Stora Gatan 1", City = "Stockholm",
                    ZipNumber = "12301", Country = country }
            };

            context.Addresses.AddOrUpdate(addresses);
        }

        private void SeedSuppliers(DataContext context)
        {
            Address address = context.Addresses.Find(1);
            Supplier[] suppliers =
            {
                new Supplier
                {
                    Id = 1, Name = "Bengts Bärs", Email = "bengt@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 2, Name = "Vlads Vodka", Email = "vlad@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 3, Name = "Cissis Cider", Email = "cissi@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 4, Name = "Pontus Punsch", Email = "pontus@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 5, Name = "Håkans Hembränt", Email = "håkan@example.net",
                    AddressId = 1
                },
            };

            context.Suppliers.AddOrUpdate(suppliers);
        }

        private void SeedCustomers(DataContext context)
        {
            Customer[] customers =
            {
                new Customer
                {
                    Id = 1, Name = "Ica", OrganizationNumber = 5560210261,
                    CreditLine = 150000, PaymentTerm = 30,
                    InvoiceAddressId = 1, VisitingAddressId = 1
                },
                new Customer
                {
                    Id = 2, Name = "Coop",
                    CreditLine = 250000, PaymentTerm = 90,
                    InvoiceAddressId = 1, VisitingAddressId = 1
                },
                new Customer
                {
                    Id= 3, Name = "Systembolaget",
                    CreditLine = 50000, PaymentTerm = 30,
                    InvoiceAddressId = 1, VisitingAddressId = 1
                }
            };

            context.Customers.AddOrUpdate(customers);
        }

        private void SeedAlcoholLicenses(DataContext context)
        {
            AlcoholLicense[] alcoholLicenses =
            {
                new AlcoholLicense {Id = 1, StartDate = DateTime.Today, EndDate = new DateTime(2020,12,24),
                    AddressId = 1, CustomerId = 1, IsValid = true},
                new AlcoholLicense {Id = 2, StartDate = DateTime.Today, EndDate = new DateTime(2021,12,24),
                    AddressId = 1, CustomerId = 1, IsValid = true},
                new AlcoholLicense {Id = 3, StartDate = DateTime.Today, EndDate = new DateTime(2022,12,24),
                    AddressId = 1, CustomerId = 1, IsValid = true},
            };

            context.AlcoholLicenses.AddOrUpdate(alcoholLicenses);
        }
    }
}
