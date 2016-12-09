
using System.Collections.Generic;
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

            SeedWarehouses(context);
            SeedSuppliers(context);
            SeedCustomers(context);
            SeedAlcoholLicenses(context);
            SeedProductCategories(context);
            SeedProducts(context);
            SeedContacts(context);

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
                    InvoiceAddressId = 1, VisitingAddressId = 1,
                    AlcoholLicenseId = 1 
                },
                new Customer
                {
                    Id = 2, Name = "Coop",
                    CreditLine = 250000, PaymentTerm = 90,
                    InvoiceAddressId = 1, VisitingAddressId = 1,
                    AlcoholLicenseId = 2
                },
                new Customer
                {
                    Id= 3, Name = "Systembolaget",
                    CreditLine = 50000, PaymentTerm = 30,
                    InvoiceAddressId = 1, VisitingAddressId = 1,
                    AlcoholLicenseId = 3
                }
            };

            context.Customers.AddOrUpdate(customers);
        }

        private void SeedAlcoholLicenses(DataContext context)
        {
            AlcoholLicense[] alcoholLicenses =
            {
                new AlcoholLicense {Id = 1, StartDate = DateTime.Today, EndDate = new DateTime(2020,12,24),
                    IsValid = true},
                new AlcoholLicense {Id = 2, StartDate = DateTime.Today, EndDate = new DateTime(2021,12,24),
                    IsValid = true},
                new AlcoholLicense {Id = 3, StartDate = DateTime.Today, EndDate = new DateTime(2022,12,24),
                    IsValid = true},
            };

            context.AlcoholLicenses.AddOrUpdate(alcoholLicenses);
        }

        private void SeedProductCategories(DataContext context)
        {
            ProductCategory[] productCategories =
            {
              new ProductCategory() {Id=1, Name = "Öl"},
              new ProductCategory() {Id=2, Name = "Cider"},
              new ProductCategory() {Id=3, Name = "Vitt vin"},
              new ProductCategory() {Id=4, Name = "Rött vin"},
              new ProductCategory() {Id=5, Name = "Sprit"},
            };
            context.ProductCategories.AddOrUpdate(productCategories);
        }
        private void SeedProducts(DataContext context)
        {
            Product[] products =
            {
                new Product()
                {
                    Id = 1, ProductCategoryId = 1, Name = "117 Grythyttan", AlcoholPercentage = 5.8m,
                    Price = 15, Description = "Humlearomatisk smak med tydlig beska, inslag av aprikos, blodgrapefrukt, gräddkola, örter och knäckebröd.",
                    ProductNumber = 88093, AccountingCode = 00100, VatCode = 02, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 2, ProductCategoryId = 1, Name = "15 Minutes of Flame", AlcoholPercentage = 5.5m,
                    Price = 25, Description = "Fruktig smak med tydlig beska, inslag av torkad frukt, knäckebröd, honung, kryddor och mandarin.",
                    ProductNumber = 31027, AccountingCode = 00100, VatCode = 02, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 3, ProductCategoryId = 2, Name = "Ahlafors ", AlcoholPercentage = 4.5m,
                    Price = 12, Description = "Kryddig, fruktig, söt smak med tydlig karaktär av ingefära, inslag av päron och citron.",
                    ProductNumber = 88093, AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 4, ProductCategoryId = 2, Name = "Alice Wilson ", AlcoholPercentage = 4.5m,
                    Price = 15, Description = "Fruktig smak med tydlig karaktär av päron, inslag av citrus och vanilj.",
                    ProductNumber =  33001, AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 5, ProductCategoryId = 3, Name = "Alvarinho Curtimenta", AlcoholPercentage = 12.5m,
                    Price = 215, Description = "Fruktig, aromatisk smak med inslag av päron, vita blommor, honung, krusbär, örter, persika och ananas.",
                    ProductNumber = 92504, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 15
                },
                new Product()
                {
                    Id = 6, ProductCategoryId = 4, Name = "Amarone ", AlcoholPercentage = 15.8m,
                    Price = 75, Description = "Kryddigt, smakrikt vin med fatkaraktär, inslag av russin, plommon, choklad, pinjenötter, pomerans och vanilj.",
                    ProductNumber = 12343, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 10
                },
            };
            context.Products.AddOrUpdate(products);

        }

        private void SeedContacts(DataContext context)
        {
            Contact[] contacts =
            {
                new Contact() {Id = 1, AdressId = 1, Email = "Göran.Eriksson@gmail.com", Name = "Göran Eriksson", PhoneNumber = "0221-34600"},
                new Contact() {Id = 2, AdressId = 1, Email = "Lisa.Nilsson@gmail.com", Name = "Lisa Nilsson", PhoneNumber = "0221-34500"},
                new Contact() {Id = 3, AdressId = 1, Email = "Henrik.Storm@gmail.com", Name = "Henrik Storm", PhoneNumber = "0589-18105"},
                new Contact() {Id = 4, AdressId = 1, Email = "Greta.Andersson@gmail.com", Name = "Greta Andersson", PhoneNumber = "08-777850"},
                new Contact() {Id = 5, AdressId = 1, Email = "Eva.Dahl@gmail.com", Name = "Eva Dahl", PhoneNumber = "0221-34600"},
            };
            context.Contacts.AddOrUpdate(contacts);
        }

        private void SeedWarehouses(DataContext context)
        {
            Warehouse[] warehouises =
            {
                new Warehouse { Id = 1, Name = "Stockholms lager", AddressId = 1, ContactId = 1, IsActive = true},
                new Warehouse { Id = 2, Name = "Göteborgs lager", AddressId = 1, ContactId = 2, IsActive = true},
                new Warehouse { Id = 3, Name = "Malmös lager", AddressId = 1, ContactId = 3, IsActive = true},
                new Warehouse { Id = 4, Name = "Faluns lager", AddressId = 1, ContactId = 4, IsActive = true},
                new Warehouse { Id = 5, Name = "Uppsalas lager", AddressId = 1, ContactId = 5, IsActive = true}
            };
            context.Warehouses.AddOrUpdate(warehouises);
        }
    }
}
