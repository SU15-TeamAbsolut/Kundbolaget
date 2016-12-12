
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
            
            Address[] addresses =
            {
                #region AddressRegion
                
                new Address { Id = 1, Street = "Stora Gatan 1", City = "Stockholm",
                    ZipNumber = "12301", CountryId = 1 },
                new Address { Id = 2, Street = "Strandgatan 20", City = "Stockholm",
                    ZipNumber = "12301", CountryId = 1 },
                new Address { Id = 3, Street = "V�straskogsv�gen 65", City = "Stockholm",
                    ZipNumber = "25630", CountryId = 1 },
                new Address { Id = 4, Street = "Blygatan 34", City = "Stockholm",
                    ZipNumber = "65307", CountryId = 1 },
                new Address { Id = 5, Street = "S�gsp�nsgatan 43", City = "Stockholm",
                    ZipNumber = "25630", CountryId = 1 },
                new Address { Id = 6, Street = "Pellesvansl�sgr�nd 32", City = "Uppsala",
                    ZipNumber = "33561", CountryId = 1 },
                new Address { Id = 7, Street = "Sp�rvagnsplan 48", City = "Stockholm",
                    ZipNumber = "44568", CountryId = 1 },
                new Address { Id = 8, Street = "Gl�db�ddsv�gen 26", City = "Stockholm",
                    ZipNumber = "25630", CountryId = 1 },
                new Address { Id = 9, Street = "Nya kvarngatan 77", City = "Stockholm",
                    ZipNumber = "21550", CountryId = 1 },
                new Address { Id = 10, Street = "Handelsgatan 22", City = "Malm�",
                    ZipNumber = "44630", CountryId = 1 },
                new Address { Id = 11, Street = "Strandgatan 20", City = "Malm�",
                    ZipNumber = "44630", CountryId = 1 },
                new Address { Id = 12, Street = "Jesusgatan 11", City = "Malm�",
                    ZipNumber = "44630", CountryId = 1 },
                new Address { Id = 13, Street = "Stenskottarv�gen 5", City = "G�teborg",
                    ZipNumber = "21213", CountryId = 1 },
                new Address { Id = 14, Street = "L�vbl�sargatan 88", City = "G�teborg",
                    ZipNumber = "21213", CountryId = 1 },
                new Address { Id = 15, Street = "Hattmakarv�gen 5", City = "G�teborg",
                    ZipNumber = "21213", CountryId = 1 },
                new Address { Id = 16, Street = "Harskuttsgatan 13", City = "G�teborg",
                    ZipNumber = "21218", CountryId = 1 },
                new Address { Id = 17, Street = "Asklundsv�gen 24", City = "G�teborg",
                    ZipNumber = "21218", CountryId = 1 },
                new Address { Id = 18, Street = "Varggatan 66", City = "�rebro",
                    ZipNumber = "85036", CountryId = 1 },
                new Address { Id = 19, Street = "B�verjagargatan 64", City = "Lindk�ping",
                    ZipNumber = "28779", CountryId = 1 },
                new Address { Id = 20, Street = "Giraffstigen 64", City = "Sundsvall",
                    ZipNumber = "44896", CountryId = 1 },
                #endregion
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
                    Id = 1, Name = "Bengts B�rs", Email = "bengt@example.net",
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
                    Id = 5, Name = "H�kans Hembr�nt", Email = "h�kan@example.net",
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
              new ProductCategory() {Id=1, Name = "�l"},
              new ProductCategory() {Id=2, Name = "Cider"},
              new ProductCategory() {Id=3, Name = "Vitt vin"},
              new ProductCategory() {Id=4, Name = "R�tt vin"},
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
                    Price = 15, Description = "Humlearomatisk smak med tydlig beska, inslag av aprikos, blodgrapefrukt, gr�ddkola, �rter och kn�ckebr�d.",
                    ProductNumber = 88093, AccountingCode = 00100, VatCode = 02, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 2, ProductCategoryId = 1, Name = "15 Minutes of Flame", AlcoholPercentage = 5.5m,
                    Price = 25, Description = "Fruktig smak med tydlig beska, inslag av torkad frukt, kn�ckebr�d, honung, kryddor och mandarin.",
                    ProductNumber = 31027, AccountingCode = 00100, VatCode = 02, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 3, ProductCategoryId = 2, Name = "Ahlafors ", AlcoholPercentage = 4.5m,
                    Price = 12, Description = "Kryddig, fruktig, s�t smak med tydlig karakt�r av ingef�ra, inslag av p�ron och citron.",
                    ProductNumber = 88093, AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 4, ProductCategoryId = 2, Name = "Alice Wilson ", AlcoholPercentage = 4.5m,
                    Price = 15, Description = "Fruktig smak med tydlig karakt�r av p�ron, inslag av citrus och vanilj.",
                    ProductNumber =  33001, AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 5, ProductCategoryId = 3, Name = "Alvarinho Curtimenta", AlcoholPercentage = 12.5m,
                    Price = 215, Description = "Fruktig, aromatisk smak med inslag av p�ron, vita blommor, honung, krusb�r, �rter, persika och ananas.",
                    ProductNumber = 92504, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 15
                },
                new Product()
                {
                    Id = 6, ProductCategoryId = 4, Name = "Amarone ", AlcoholPercentage = 15.8m,
                    Price = 75, Description = "Kryddigt, smakrikt vin med fatkarakt�r, inslag av russin, plommon, choklad, pinjen�tter, pomerans och vanilj.",
                    ProductNumber = 12343, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 10
                },
            };
            context.Products.AddOrUpdate(products);

        }

        private void SeedContacts(DataContext context)
        {
            Contact[] contacts =
            {
                new Contact() {Id = 1, AdressId = 1, Email = "G�ran.Eriksson@gmail.com", Name = "G�ran Eriksson", PhoneNumber = "0221-34600"},
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
                new Warehouse { Id = 2, Name = "G�teborgs lager", AddressId = 1, ContactId = 2, IsActive = true},
                new Warehouse { Id = 3, Name = "Malm�s lager", AddressId = 1, ContactId = 3, IsActive = true},
                new Warehouse { Id = 4, Name = "Faluns lager", AddressId = 1, ContactId = 4, IsActive = true},
                new Warehouse { Id = 5, Name = "Uppsalas lager", AddressId = 1, ContactId = 5, IsActive = true}
            };
            context.Warehouses.AddOrUpdate(warehouises);
        }
    }
}
