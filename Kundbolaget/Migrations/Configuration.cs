
using System.Collections.Generic;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Enums;

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
            SeedProductPrices(context);

            SeedContacts(context);

            // No seeded order data!
            //SeedOrders(context);
            //SeedOrderRows(context);

            SeedShelves(context);
            SeedProductsShelves(context);
        }

        private void SeedProductPrices(DataContext context)
        {
            ProductPrice[] prices =
            {
                new ProductPrice { Id = 1, ProductId = 10000, Price = 180, StartDate = DateTime.Now.AddDays(-90) },
                new ProductPrice { Id = 2, ProductId = 10000, Price = 290, StartDate = DateTime.Now.AddDays(-60) },
                new ProductPrice { Id = 3, ProductId = 10000, Price = 270, StartDate = DateTime.Now.AddDays(-30) },
                new ProductPrice { Id = 4, ProductId = 10000, Price = 350, StartDate = DateTime.Now.AddDays(-7) },
                new ProductPrice { Id = 5, ProductId = 10000, Price = 90, StartDate = DateTime.Now.AddDays(7) },
                new ProductPrice { Id = 6, ProductId = 10000, Price = 220, StartDate = DateTime.Now.AddDays(30) },
            };

            context.ProductPrices.AddOrUpdate(prices);
        }

        private void SeedProductsShelves(DataContext context)
        {
            ProductShelf[] productsShelves =
            {
                new ProductShelf { Id = 1, CurrentAmount = 18, MinimumAmount = 5, ProductId = 10000, ShelfId = 1, Position = "1" },
                new ProductShelf { Id = 2, CurrentAmount = 3, MinimumAmount = 5, ProductId = 10001, ShelfId = 1, Position = "2" },
                new ProductShelf { Id = 3, CurrentAmount = 95, MinimumAmount = 5, ProductId = 10002, ShelfId = 1, Position = "3" },
                new ProductShelf { Id = 4, CurrentAmount = 65, MinimumAmount = 5, ProductId = 10003, ShelfId = 1, Position = "4" },
                new ProductShelf { Id = 5, CurrentAmount = 436, MinimumAmount = 5, ProductId = 10004, ShelfId = 1, Position = "5" },
                new ProductShelf { Id = 6, CurrentAmount = 63, MinimumAmount = 5, ProductId = 10005, ShelfId = 1, Position = "6" },
                new ProductShelf { Id = 7, CurrentAmount = 72, MinimumAmount = 5, ProductId = 10006, ShelfId = 1, Position = "7" },
                new ProductShelf { Id = 8, CurrentAmount = 73, MinimumAmount = 5, ProductId = 10007, ShelfId = 2, Position = "1" },
                new ProductShelf { Id = 9, CurrentAmount = 117, MinimumAmount = 5, ProductId = 10008, ShelfId = 2, Position = "2" },
                new ProductShelf { Id = 10, CurrentAmount = 19, MinimumAmount = 5, ProductId = 10009, ShelfId = 2, Position = "3" },
                new ProductShelf { Id = 11, CurrentAmount = 91, MinimumAmount = 5, ProductId = 10010, ShelfId = 2, Position = "4" },
                new ProductShelf { Id = 12, CurrentAmount = 81, MinimumAmount = 5, ProductId = 10011, ShelfId = 2, Position = "5" },
                new ProductShelf { Id = 13, CurrentAmount = 71, MinimumAmount = 5, ProductId = 10012, ShelfId = 2, Position = "6" },
                new ProductShelf { Id = 14, CurrentAmount = 85, MinimumAmount = 5, ProductId = 10013, ShelfId = 2, Position = "7" },
                new ProductShelf { Id = 15, CurrentAmount = 58, MinimumAmount = 5, ProductId = 10014, ShelfId = 2, Position = "8" },
                new ProductShelf { Id = 16, CurrentAmount = 51, MinimumAmount = 5, ProductId = 10015, ShelfId = 2, Position = "9" },
                new ProductShelf { Id = 17, CurrentAmount = 47, MinimumAmount = 5, ProductId = 10016, ShelfId = 2, Position = "10" },
                new ProductShelf { Id = 18, CurrentAmount = 15, MinimumAmount = 5, ProductId = 10017, ShelfId = 3, Position = "1" },
                new ProductShelf { Id = 19, CurrentAmount = 61, MinimumAmount = 5, ProductId = 10018, ShelfId = 3, Position = "2" },
                new ProductShelf { Id = 20, CurrentAmount = 72, MinimumAmount = 5, ProductId = 10019, ShelfId = 3, Position = "3" },
                new ProductShelf { Id = 21, CurrentAmount = 82, MinimumAmount = 5, ProductId = 10020, ShelfId = 3, Position = "4" },
                new ProductShelf { Id = 22, CurrentAmount = 79, MinimumAmount = 5, ProductId = 10021, ShelfId = 3, Position = "5" },
                new ProductShelf { Id = 23, CurrentAmount = 41, MinimumAmount = 5, ProductId = 10022, ShelfId = 4, Position = "1" },
                new ProductShelf { Id = 24, CurrentAmount = 16, MinimumAmount = 5, ProductId = 10023, ShelfId = 4, Position = "2" },
                new ProductShelf { Id = 25, CurrentAmount = 17, MinimumAmount = 5, ProductId = 10024, ShelfId = 4, Position = "3" },
                new ProductShelf { Id = 26, CurrentAmount = 71, MinimumAmount = 5, ProductId = 10025, ShelfId = 5, Position = "1" },
                new ProductShelf { Id = 27, CurrentAmount = 79, MinimumAmount = 5, ProductId = 10026, ShelfId = 5, Position = "2" },
                new ProductShelf { Id = 28, CurrentAmount = 91, MinimumAmount = 5, ProductId = 10027, ShelfId = 5, Position = "3" },
                new ProductShelf { Id = 29, CurrentAmount = 107, MinimumAmount = 5, ProductId = 10028, ShelfId = 6, Position = "1" },
                new ProductShelf { Id = 30, CurrentAmount = 61, MinimumAmount = 5, ProductId = 10029, ShelfId = 6, Position = "2" },
                new ProductShelf { Id = 31, CurrentAmount = 1, MinimumAmount = 5, ProductId = 10030, ShelfId = 7, Position = "1" },
                new ProductShelf { Id = 32, CurrentAmount = 72, MinimumAmount = 5, ProductId = 10031, ShelfId = 7, Position = "2" },
                new ProductShelf { Id = 33, CurrentAmount = 16, MinimumAmount = 5, ProductId = 10032, ShelfId = 7, Position = "3" },
                new ProductShelf { Id = 34, CurrentAmount = 50, MinimumAmount = 5, ProductId = 10033, ShelfId = 8, Position = "1" },
                new ProductShelf { Id = 35, CurrentAmount = 50, MinimumAmount = 5, ProductId = 10034, ShelfId = 8, Position = "2" },

            };
            context.ProductsShelves.AddOrUpdate(productsShelves);
        }

        private void SeedShelves(DataContext context)
        {
            Shelf[] shelves =
            {
                new Shelf { Id = 1, Name = "A", WarehouseId = 0 },
                new Shelf { Id = 2, Name = "B", WarehouseId = 0 },
                new Shelf { Id = 3, Name = "C", WarehouseId = 0 },
                new Shelf { Id = 4, Name = "D", WarehouseId = 0 },
                new Shelf { Id = 5, Name = "E", WarehouseId = 0 },
                new Shelf { Id = 6, Name = "F", WarehouseId = 0 },
                new Shelf { Id = 7, Name = "G", WarehouseId = 0 },
                new Shelf { Id = 8, Name = "H", WarehouseId = 0 }
            };
            context.Shelves.AddOrUpdate(shelves);
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
                new Address { Id = 3, Street = "Västraskogsvägen 65", City = "Stockholm",
                    ZipNumber = "25630", CountryId = 1 },
                new Address { Id = 4, Street = "Blygatan 34", City = "Stockholm",
                    ZipNumber = "65307", CountryId = 1 },
                new Address { Id = 5, Street = "Sågspånsgatan 43", City = "Stockholm",
                    ZipNumber = "25630", CountryId = 1 },
                new Address { Id = 6, Street = "Pellesvanslösgränd 32", City = "Uppsala",
                    ZipNumber = "33561", CountryId = 1 },
                new Address { Id = 7, Street = "Spårvagnsplan 48", City = "Stockholm",
                    ZipNumber = "44568", CountryId = 1 },
                new Address { Id = 8, Street = "Glödbäddsvägen 26", City = "Stockholm",
                    ZipNumber = "25630", CountryId = 1 },
                new Address { Id = 9, Street = "Nya kvarngatan 77", City = "Stockholm",
                    ZipNumber = "21550", CountryId = 1 },
                new Address { Id = 10, Street = "Handelsgatan 22", City = "Malmö",
                    ZipNumber = "44630", CountryId = 1 },
                new Address { Id = 11, Street = "Strandgatan 20", City = "Malmö",
                    ZipNumber = "44630", CountryId = 1 },
                new Address { Id = 12, Street = "Jesusgatan 11", City = "Malmö",
                    ZipNumber = "44630", CountryId = 1 },
                new Address { Id = 13, Street = "Stenskottarvägen 5", City = "Göteborg",
                    ZipNumber = "21213", CountryId = 1 },
                new Address { Id = 14, Street = "Lövblåsargatan 88", City = "Göteborg",
                    ZipNumber = "21213", CountryId = 1 },
                new Address { Id = 15, Street = "Hattmakarvägen 5", City = "Göteborg",
                    ZipNumber = "21213", CountryId = 1 },
                new Address { Id = 16, Street = "Harskuttsgatan 13", City = "Göteborg",
                    ZipNumber = "21218", CountryId = 1 },
                new Address { Id = 17, Street = "Asklundsvägen 24", City = "Göteborg",
                    ZipNumber = "21218", CountryId = 1 },
                new Address { Id = 18, Street = "Varggatan 66", City = "Örebro",
                    ZipNumber = "85036", CountryId = 1 },
                new Address { Id = 19, Street = "Bäverjagargatan 64", City = "Lindköping",
                    ZipNumber = "28779", CountryId = 1 },
                new Address { Id = 20, Street = "Giraffstigen 64", City = "Sundsvall",
                    ZipNumber = "44896", CountryId = 1 },
                new Address { Id = 21, Street = "Älgstigen 64", City = "Uppsala",
                    ZipNumber = "45953", CountryId = 1 },
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
                    Id = 1, Name = "Gotlands Bryggeri AB", Email = "Gotland@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 2, Name = "The Absolut Company AB", Email = "Absolut@example.net",
                    AddressId = 2
                },
                new Supplier
                {
                    Id = 3, Name = "Mackmyra Svensk Whisky", Email = "Mackmyra@example.net",
                    AddressId = 3
                },
                new Supplier
                {
                    Id = 4, Name = "Åbro Wines (AB Åbro Bryggeri)", Email = "Åbro@example.net",
                    AddressId = 4
                },
                new Supplier
                {
                    Id = 5, Name = "Arvid Nordquist Vin och Sprithandel", Email = "Nordquist@example.net",
                    AddressId = 5
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
                    InvoiceAddressId = 9, VisitingAddressId = 6,
                    AlcoholLicenseId = 1,ContactId = 8,
                    ShippingAddresses = new List<Address>()
                    {
                        new Address
                        {
                            Id = 22,
                            Street = "Borgaregatan 52",
                            City = "Arboga",
                            ZipNumber = "73247",
                            CountryId = 1
                        },
                        new Address
                        {
                            Id = 23,
                            Street = "Nygatan 12",
                            City = "Västerås",
                            ZipNumber = "62154",
                            CountryId = 1
                        },
                        new Address
                        {
                            Id = 24,
                            Street = "Rådhusgatan 112",
                            City = "Stockholm",
                            ZipNumber = "45999",
                            CountryId = 1
                        },
                    }
                },
                new Customer
                {
                    Id = 2, Name = "Coop", OrganizationNumber = 5567105480,
                    CreditLine = 250000, PaymentTerm = 90,
                    InvoiceAddressId = 10, VisitingAddressId = 7,
                    AlcoholLicenseId = 2,ContactId = 7,
                    ShippingAddresses = new List<Address>()
                    {
                        new Address
                        {
                            Id = 25,
                            Street = "Klarinettvägen 6",
                            City = "Göteborg",
                            ZipNumber = "34579",
                            CountryId = 1,
                        },
                        new Address
                        {
                            Id = 26,
                            Street = "Hållbacksvägen 4",
                            City = "Kiruna",
                            ZipNumber = "45012",
                            CountryId = 1
                        },
                        new Address
                        {
                            Id = 27,
                            Street = "Valthornsgatan 56",
                            City = "Stockholm",
                            ZipNumber = "48145",
                            CountryId = 1
                        },
                    }
                    
                },
                new Customer
                {
                    Id= 3, Name = "Systembolaget", OrganizationNumber = 5560599473,
                    CreditLine = 50000, PaymentTerm = 30,
                    InvoiceAddressId = 11, VisitingAddressId = 8,
                    AlcoholLicenseId = 3,ContactId = 6,
                    ShippingAddresses = new List<Address>()
                    {
                        new Address
                        {
                            Id = 28,
                            Street = "Studentvägen 13",
                            City = "Uppsala",
                            ZipNumber = "45977",
                            CountryId = 1
                        },
                        new Address
                        {
                            Id = 29,
                            Street = "Hågavägen 7",
                            City = "Arboga",
                            ZipNumber = "78915",
                            CountryId = 1
                        },
                    }
                }
            };

            context.Customers.AddOrUpdate(customers);
        }

        private void SeedAlcoholLicenses(DataContext context)
        {
            AlcoholLicense[] alcoholLicenses =
            {
                new AlcoholLicense {Id = 1, StartDate = DateTime.Today, EndDate = new DateTime(2020,12,24)},
                new AlcoholLicense {Id = 2, StartDate = DateTime.Today, EndDate = new DateTime(2021,12,24)},
                new AlcoholLicense {Id = 3, StartDate = DateTime.Today, EndDate = new DateTime(2022,12,24), IsActive = false},
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
              new ProductCategory() {Id=5, Name = "Rom"},
              new ProductCategory() {Id=6, Name = "Whisky"},
              new ProductCategory() {Id=7, Name = "Gin"},
              new ProductCategory() {Id=8, Name = "Sherry"},
              new ProductCategory() {Id=9, Name = "Tequila"},
              new ProductCategory() {Id=10, Name = "Glögg"},

            };
            context.ProductCategories.AddOrUpdate(productCategories);
        }

        private void SeedProducts(DataContext context)
        {
            Product[] products =
            {
                #region Product seed data
                new Product()
                {
                    Id = 1, ProductCategoryId = 1, Name = "117 Grythyttan", AlcoholPercentage = 5.8m,
                    Price = 300, Description = "Humlearomatisk smak med tydlig beska, inslag av aprikos, blodgrapefrukt, gräddkola, örter och knäckebröd.", AccountingCode = 00100, VatCode = 02, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 2, ProductCategoryId = 1, Name = "15 Minutes of Flame", AlcoholPercentage = 5.5m,
                    Price = 125, Description = "Fruktig smak med tydlig beska, inslag av torkad frukt, knäckebröd, honung, kryddor och mandarin.", AccountingCode = 00100, VatCode = 02, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 3, ProductCategoryId = 2, Name = "Ahlafors ", AlcoholPercentage = 4.5m,
                    Price = 240, Description = "Kryddig, fruktig, söt smak med tydlig karaktär av ingefära, inslag av päron och citron.", AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 4, ProductCategoryId = 2, Name = "Alice Wilson ", AlcoholPercentage = 4.5m,
                    Price = 300, Description = "Fruktig smak med tydlig karaktär av päron, inslag av citrus och vanilj.", AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 5, ProductCategoryId = 3, Name = "Alvarinho Curtimenta", AlcoholPercentage = 12.5m,
                    Price = 1290, Description = "Fruktig, aromatisk smak med inslag av päron, vita blommor, honung, krusbär, örter, persika och ananas.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 6, ProductCategoryId = 4, Name = "Amarone", AlcoholPercentage = 15.8m,
                    Price = 450, Description = "Kryddigt, smakrikt vin med fatkaraktär, inslag av russin, plommon, choklad, pinjenötter, pomerans och vanilj.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 7, ProductCategoryId = 3, Name = "Bennati Soave Classico", AlcoholPercentage = 12.5m,
                    Price = 510, Description = "Fruktig, något blommig doft med inslag av päron, ananas och citrus.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 8, ProductCategoryId = 3, Name = "Calvet Réserve Sauvignon Blanc", AlcoholPercentage = 11.5m,
                    Price = 714, Description = "Fruktig, aromatisk doft med inslag gröna äpplen, färska örter, gula päron och citrus.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 9, ProductCategoryId = 3, Name = "Iona Sauvignon Blanc", AlcoholPercentage = 14m,
                    Price = 810, Description = "Aromatisk, ungdomlig, fruktig doft med inslag av krusbär, päron, nässlor och citrus.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 10, ProductCategoryId = 3, Name = "Running Duck Sauvignon Blanc Semillon", AlcoholPercentage = 13m,
                    Price = 474, Description = "Fruktig, aromatisk doft med inslag av päron, nässlor, sparris och lime.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 11, ProductCategoryId = 4, Name = "Allegrini Valpolicella Superiore", AlcoholPercentage = 13.5m,
                    Price = 654, Description = "Nyanserad, kryddig doft med inslag av fat, mörka bär, peppar, mynta och mörk choklad.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 12, ProductCategoryId = 4, Name = "Barbera del Monferrato Livio Pavese", AlcoholPercentage = 14m,
                    Price = 654, Description = "Kryddig, utvecklad doft med fatkaraktär, inslag av torkade körsbär, tobak, korinter, mörk choklad och lavendel.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 13, ProductCategoryId = 4, Name = "Brunello di Montalcino Fattoi", AlcoholPercentage = 15m,
                    Price = 1314, Description = "Kryddig, utvecklad doft med fatkaraktär, inslag av torkade körsbär, nougat, pomerans, kanel, tobak och peppar.", AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 14, ProductCategoryId = 5, Name = "Angostura 1919", AlcoholPercentage = 40m,
                    Price = 2154, Description = "Stor, nyanserad doft med tydlig fatkaraktär, inslag av mango, ananas, vaniljfudge, marsipan och arrak.", AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 15, ProductCategoryId = 5, Name = "Brugal 1888 Gran Reserva Familiar", AlcoholPercentage = 40m,
                    Price = 2994, Description = "Nyanserad doft med tydlig fatkaraktär, inslag av torkade dadlar, apelsinmarmelad, choklad, farinsocker och vanilj.", AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 16, ProductCategoryId = 5, Name = "Havana Club Añejo Blanco", AlcoholPercentage = 37.5m,
                    Price = 1494, Description = "Fruktig doft med inslag av päron, arrak, gräs och vanilj.", AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 17, ProductCategoryId = 5, Name = "Plantation Nr 509 20th Anniversary XO Barbados", AlcoholPercentage = 40m,
                    Price = 3054, Description = "Komplex, kryddig doft med tydlig fatkaraktär, inslag av torkad frukt, mandelmassa, kokos, muscovadosocker, arrak och vanilj.", AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 18, ProductCategoryId = 2, Name = "Cider Rosé", AlcoholPercentage = 5m,
                    Price = 600, Description = "Nyanserad, fruktig doft med inslag av röda äpplen, kryddor, halm och smultron.", AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 19, ProductCategoryId = 2, Name = "Kiviks Ekologisk Äppelcider", AlcoholPercentage = 4.5m,
                    Price = 480, Description = "Fruktig doft med tydlig karaktär av äpplen, inslag av örter, päron och citrus.", AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 24
                },
                new Product()
                {
                    Id = 20, ProductCategoryId = 2, Name = "Make Momma Proud", AlcoholPercentage = 6m,
                    Price = 888, Description = "Fruktig doft med tydlig karaktär av röda äpplen, inslag av passionsfrukt, honung och citrus.", AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 24
                },
                new Product()
                {
                    Id = 21, ProductCategoryId = 6, Name = "Ardbeg Uigeadail", AlcoholPercentage = 54.2m,
                    Price = 4194, Description = "Komplex, påtaglig rökig doft med fatkaraktär, inslag av aprikos, tjära, mörk choklad, jod och nötter.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 22, ProductCategoryId = 6, Name = "Bell's ", AlcoholPercentage = 40,
                    Price = 1434, Description = "Aningen maltig doft med inslag av fat, halm, valnötter och rök.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 23, ProductCategoryId = 6, Name = "Blanton's", AlcoholPercentage = 51.5m,
                    Price = 3234, Description = "Komplex doft med karaktär av kolade ekfat, inslag av apelsinchoklad, torkade aprikoser, nougat, örter och vaniljfudge.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 24, ProductCategoryId = 6, Name = "Evan Williams ", AlcoholPercentage = 43m,
                    Price = 1794, Description = "Kryddig doft med tydlig karaktär av kolade ekfat, inslag av torkade aprikoser, nötter, knäck, kokos och vanilj.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 25, ProductCategoryId = 7, Name = "Beefeater London Dry Gin", AlcoholPercentage = 40m,
                    Price = 1500, Description = "Kryddig doft med inslag av enbär, citron och korianderfrö.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 26, ProductCategoryId = 7, Name = "Göteborg Gin Old Fashioned Gin", AlcoholPercentage = 45m,
                    Price = 2360, Description = "Kryddig smak med inslag av citrusskal, enbär, päron och koriander. Serveras som drinkingrediens.", AccountingCode = 00200, VatCode = 01, Volume = 500, PackageAmount = 8
                },
                new Product()
                {
                    Id = 27, ProductCategoryId = 7, Name = "Gordon's London Dry Gin", AlcoholPercentage = 37.5m,
                    Price = 1434, Description = "Stor doft med tydlig karaktär av enbär, inslag av koriander, örter och citrus.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 28, ProductCategoryId = 8, Name = "Lustau Solera Reserva", AlcoholPercentage = 18.5m,
                    Price = 990, Description = "Nyanserad doft med inslag av torkad frukt, hasselnötter, choklad och apelsinskal.", AccountingCode = 00200, VatCode = 01, Volume = 375, PackageAmount = 10
                },
                new Product()
                {
                    Id = 29, ProductCategoryId = 8, Name = "Dry Sack", AlcoholPercentage = 15m,
                    Price = 594, Description = "Nötig, druvig doft med inslag av pomerans, nougat, torkade fikon och örter.", AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 30, ProductCategoryId = 8, Name = "Lustau Solera Reserva Dublett", AlcoholPercentage = 18.5m,
                    Price = 990, Description = "Nyanserad smak med inslag av torkad frukt, hasselnötter, choklad, farinsocker och apelsinskal. Serveras vid cirka 14°C som aperitif eller till kallskuret.", AccountingCode = 00200, VatCode = 01, Volume = 375, PackageAmount = 10
                },
                new Product()
                {
                    Id = 31, ProductCategoryId = 9, Name = "El Paseillo Charro", AlcoholPercentage = 40m,
                    Price = 2394, Description = "Nyanserad, kryddig smak med tydlig fatkaraktär, inslag av halm, vanilj, pomerans, örter och vanilj. Serveras rumstempererad som digestif.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 32, ProductCategoryId = 9, Name = "Patrón", AlcoholPercentage = 40m,
                    Price = 4194, Description = "Nyanserad smak med fatkaraktär, inslag av färska örter, macadamianötter, päron, halm och citrusskal. Serveras rumstempererad som digestif.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 33, ProductCategoryId = 9, Name = "Sierra Tequila Silver", AlcoholPercentage = 38m,
                    Price = 1194, Description = "Robust smak med inslag av gräs och citrusskal. Används som drinkingrediens.", AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 34, ProductCategoryId = 10, Name = "Blossa Starkvinsglögg", AlcoholPercentage = 38m,
                    Price = 498, Description = "Kryddig, mycket söt smak med inslag av kryddnejlika, ingefära, russin och kanel.", AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 6
                },
                new Product()
                {
                    Id = 35, ProductCategoryId = 10, Name = "Dufvenkrooks Julspecial", AlcoholPercentage = 20m,
                    Price = 760, Description = "Söt, kryddig smak med inslag av ingefära, muskot, kardemumma, röda äpplen, pomerans, torkad frukt och örter.", AccountingCode = 00200, VatCode = 01, Volume = 500, PackageAmount = 8
                },
                new Product()
                {
                    Id = 36, ProductCategoryId = 10, Name = "Grythyttan Skogsglögg", AlcoholPercentage = 14.5m,
                    Price = 596, Description = "Kryddig, söt smak med inslag av lingon, blåbär, kanel, kryddnejlika, pomerans och ingefära.", AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 6
                },
                #endregion
            };

            context.Products.AddOrUpdate(p => p.Name, products);
        }

        private void SeedContacts(DataContext context)
        {
            Contact[] contacts =
            {
                new Contact() {Id = 1, AdressId = 12, Email = "G�ran.Eriksson@gmail.com", Name = "G�ran Eriksson", PhoneNumber = "0221-34600"},
                new Contact() {Id = 2, AdressId = 13, Email = "Lisa.Nilsson@gmail.com", Name = "Lisa Nilsson", PhoneNumber = "0221-34500"},
                new Contact() {Id = 3, AdressId = 14, Email = "Henrik.Storm@gmail.com", Name = "Henrik Storm", PhoneNumber = "0589-18105"},
                new Contact() {Id = 4, AdressId = 15, Email = "Greta.Andersson@gmail.com", Name = "Greta Andersson", PhoneNumber = "08-777850"},
                new Contact() {Id = 5, AdressId = 16, Email = "Eva.Dahl@gmail.com", Name = "Eva Dahl", PhoneNumber = "0221-34600"},
                new Contact() {Id = 6, AdressId = 6, Email = "Erik.Svensson@gmail.com", Name = "Erik Svensson", PhoneNumber = "0221-34800"},
                new Contact() {Id = 7, AdressId = 7, Email = "Fredrik.Ekström@gmail.com", Name = "Fredrik Ekström", PhoneNumber = "08-789120"},
                new Contact() {Id = 8, AdressId = 8, Email = "Stina.Eriksson@gmail.com", Name = "Stina Eriksson", PhoneNumber = "08-12580"},
            };
            context.Contacts.AddOrUpdate(contacts);
        }

        private void SeedWarehouses(DataContext context)
        {
            Warehouse[] warehouses =
            {
                new Warehouse { Id = 0, Name = "Stockholms lager", AddressId = 3, ContactId = 1, IsActive = true}
            };
            context.Warehouses.AddOrUpdate(warehouses);
        }

        private void SeedOrders(DataContext context)
        {
            Order[] orders =
            {
                new Order
                {
                    Id = 1,
                    CustomerId = 3,
                    OrderPlaced = DateTime.Now,
                    DesiredDeliveryDate = DateTime.Now.AddDays(5),
                    OrderStatus = OrderStatus.Registered,
                    ShippingAddressId = 11,
                    OrderRows = new List<OrderRow>()
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 1,
                    OrderPlaced = DateTime.Now,
                    DesiredDeliveryDate = DateTime.Now.AddDays(5),
                    OrderStatus = OrderStatus.Registered,
                    ShippingAddressId = 9,
                    OrderRows = new List<OrderRow>()
                }
            };
            context.Orders.AddOrUpdate(orders);
        }

        private void SeedOrderRows(DataContext context)
        {
            OrderRow[] orderRows =
            {
                new OrderRow {OrderId = 1, ProductId = 1, AmountOrdered = 30},
                new OrderRow {OrderId = 1, ProductId = 7, AmountOrdered = 8},
                new OrderRow {OrderId = 1, ProductId = 10, AmountOrdered = 14},
                new OrderRow {OrderId = 2, ProductId = 15, AmountOrdered = 40},
                new OrderRow {OrderId = 2, ProductId = 17, AmountOrdered = 18},
                new OrderRow {OrderId = 2, ProductId = 10, AmountOrdered = 14}

            };
            context.OrderRows.AddOrUpdate(orderRows);
        }

    }
}
