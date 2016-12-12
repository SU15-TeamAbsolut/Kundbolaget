
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
                    Id = 1, Name = "Gotlands Bryggeri AB", Email = "Gotland@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 2, Name = "The Absolut Company AB", Email = "Absolut@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 3, Name = "Mackmyra Svensk Whisky", Email = "Mackmyra@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 4, Name = "�bro Wines (AB �bro Bryggeri)", Email = "�bro@example.net",
                    AddressId = 1
                },
                new Supplier
                {
                    Id = 5, Name = "Arvid Nordquist Vin och Sprithandel", Email = "Nordquist@example.net",
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
              new ProductCategory() {Id=5, Name = "Rom"},
              new ProductCategory() {Id=6, Name = "Whisky"},
              new ProductCategory() {Id=7, Name = "Gin"},
              new ProductCategory() {Id=8, Name = "Sherry"},
              new ProductCategory() {Id=9, Name = "Tequila"},
              new ProductCategory() {Id=10, Name = "Gl�gg"},

            };
            context.ProductCategories.AddOrUpdate(productCategories);
        }
        private void SeedProducts(DataContext context)
        {
            Product[] products =
            {
#region ProductsRegion
                
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
                    Id = 6, ProductCategoryId = 4, Name = "Amarone", AlcoholPercentage = 15.8m,
                    Price = 75, Description = "Kryddigt, smakrikt vin med fatkarakt�r, inslag av russin, plommon, choklad, pinjen�tter, pomerans och vanilj.",
                    ProductNumber = 12343, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 10
                },
                new Product()
                {
                    Id = 7, ProductCategoryId = 3, Name = "Bennati Soave Classico", AlcoholPercentage = 12.5m,
                    Price = 85, Description = "Fruktig, n�got blommig doft med inslag av p�ron, ananas och citrus.",
                    ProductNumber = 2114, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 8, ProductCategoryId = 3, Name = "Calvet R�serve Sauvignon Blanc", AlcoholPercentage = 11.5m,
                    Price = 119, Description = "Fruktig, aromatisk doft med inslag gr�na �pplen, f�rska �rter, gula p�ron och citrus.",
                    ProductNumber = 74725, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 9, ProductCategoryId = 3, Name = "Iona Sauvignon Blanc", AlcoholPercentage = 14m,
                    Price = 135, Description = "Aromatisk, ungdomlig, fruktig doft med inslag av krusb�r, p�ron, n�sslor och citrus.",
                    ProductNumber = 92062, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 10, ProductCategoryId = 3, Name = "Running Duck Sauvignon Blanc Semillon", AlcoholPercentage = 13m,
                    Price = 79, Description = "Fruktig, aromatisk doft med inslag av p�ron, n�sslor, sparris och lime.",
                    ProductNumber = 2028, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 11, ProductCategoryId = 4, Name = "Allegrini Valpolicella Superiore", AlcoholPercentage = 13.5m,
                    Price = 109, Description = "Nyanserad, kryddig doft med inslag av fat, m�rka b�r, peppar, mynta och m�rk choklad.",
                    ProductNumber = 6010, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 12, ProductCategoryId = 4, Name = "Barbera del Monferrato Livio Pavese", AlcoholPercentage = 14m,
                    Price = 109, Description = "Kryddig, utvecklad doft med fatkarakt�r, inslag av torkade k�rsb�r, tobak, korinter, m�rk choklad och lavendel.",
                    ProductNumber = 74960, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 13, ProductCategoryId = 4, Name = "Brunello di Montalcino Fattoi", AlcoholPercentage = 15m,
                    Price = 219, Description = "Kryddig, utvecklad doft med fatkarakt�r, inslag av torkade k�rsb�r, nougat, pomerans, kanel, tobak och peppar.",
                    ProductNumber = 3097, AccountingCode = 00300, VatCode = 03, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 14, ProductCategoryId = 5, Name = "Angostura 1919", AlcoholPercentage = 40m,
                    Price = 359, Description = "Stor, nyanserad doft med tydlig fatkarakt�r, inslag av mango, ananas, vaniljfudge, marsipan och arrak.",
                    ProductNumber = 504, AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 15, ProductCategoryId = 5, Name = "Brugal 1888 Gran Reserva Familiar", AlcoholPercentage = 40m,
                    Price = 499, Description = "Nyanserad doft med tydlig fatkarakt�r, inslag av torkade dadlar, apelsinmarmelad, choklad, farinsocker och vanilj.",
                    ProductNumber = 590, AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 16, ProductCategoryId = 5, Name = "Havana Club A�ejo Blanco", AlcoholPercentage = 37.5m,
                    Price = 249, Description = "Fruktig doft med inslag av p�ron, arrak, gr�s och vanilj.",
                    ProductNumber = 511, AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 17, ProductCategoryId = 5, Name = "Plantation Nr 509 20th Anniversary XO Barbados", AlcoholPercentage = 40m,
                    Price = 509, Description = "Komplex, kryddig doft med tydlig fatkarakt�r, inslag av torkad frukt, mandelmassa, kokos, muscovadosocker, arrak och vanilj.",
                    ProductNumber = 509, AccountingCode = 00300, VatCode = 03, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 18, ProductCategoryId = 2, Name = "Cidre Ros�", AlcoholPercentage = 5m,
                    Price = 75, Description = "Nyanserad, fruktig doft med inslag av r�da �pplen, kryddor, halm och smultron.",
                    ProductNumber = 11808, AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 19, ProductCategoryId = 2, Name = "Kiviks Ekologisk �ppelcider", AlcoholPercentage = 4.5m,
                    Price = 18.9m, Description = "Fruktig doft med tydlig karakt�r av �pplen, inslag av �rter, p�ron och citrus.",
                    ProductNumber = 1892, AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 20, ProductCategoryId = 2, Name = "Make Momma Proud", AlcoholPercentage = 6m,
                    Price = 36.9m, Description = "Fruktig doft med tydlig karakt�r av r�da �pplen, inslag av passionsfrukt, honung och citrus.",
                    ProductNumber = 11807, AccountingCode = 00200, VatCode = 01, Volume = 330, PackageAmount = 20
                },
                new Product()
                {
                    Id = 21, ProductCategoryId = 6, Name = "Ardbeg Uigeadail", AlcoholPercentage = 54.2m,
                    Price = 699, Description = "Komplex, p�taglig r�kig doft med fatkarakt�r, inslag av aprikos, tj�ra, m�rk choklad, jod och n�tter.",
                    ProductNumber = 10407, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 22, ProductCategoryId = 6, Name = "Bell's ", AlcoholPercentage = 40,
                    Price = 239, Description = "Aningen maltig doft med inslag av fat, halm, valn�tter och r�k.",
                    ProductNumber = 406, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 23, ProductCategoryId = 6, Name = "Blanton's", AlcoholPercentage = 51.5m,
                    Price = 539, Description = "Komplex doft med karakt�r av kolade ekfat, inslag av apelsinchoklad, torkade aprikoser, nougat, �rter och vaniljfudge.",
                    ProductNumber = 557, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 24, ProductCategoryId = 6, Name = "Evan Williams ", AlcoholPercentage = 43m,
                    Price = 299, Description = "Kryddig doft med tydlig karakt�r av kolade ekfat, inslag av torkade aprikoser, n�tter, kn�ck, kokos och vanilj.",
                    ProductNumber = 560, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 6
                },
                new Product()
                {
                    Id = 25, ProductCategoryId = 7, Name = "Beefeater London Dry Gin", AlcoholPercentage = 40m,
                    Price = 250, Description = "Kryddig doft med inslag av enb�r, citron och korianderfr�.",
                    ProductNumber = 39, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 8
                },
                new Product()
                {
                    Id = 26, ProductCategoryId = 7, Name = "G�teborg Gin Old Fashioned Gin", AlcoholPercentage = 45m,
                    Price = 295, Description = "Kryddig smak med inslag av citrusskal, enb�r, p�ron och koriander. Serveras som drinkingrediens.",
                    ProductNumber = 30279, AccountingCode = 00200, VatCode = 01, Volume = 500, PackageAmount = 10
                },
                new Product()
                {
                    Id = 27, ProductCategoryId = 7, Name = "Gordon's London Dry Gin", AlcoholPercentage = 37.5m,
                    Price = 239, Description = "Stor doft med tydlig karakt�r av enb�r, inslag av koriander, �rter och citrus.",
                    ProductNumber = 35, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 8
                },
                new Product()
                {
                    Id = 28, ProductCategoryId = 8, Name = "Lustau Solera Reserva", AlcoholPercentage = 18.5m,
                    Price = 99, Description = "Nyanserad doft med inslag av torkad frukt, hasseln�tter, choklad och apelsinskal.",
                    ProductNumber = 8227, AccountingCode = 00200, VatCode = 01, Volume = 375, PackageAmount = 10
                },
                new Product()
                {
                    Id = 29, ProductCategoryId = 8, Name = "Dry Sack", AlcoholPercentage = 15m,
                    Price = 99, Description = "N�tig, druvig doft med inslag av pomerans, nougat, torkade fikon och �rter.",
                    ProductNumber = 8209, AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 30, ProductCategoryId = 8, Name = "Lustau Solera Reserva", AlcoholPercentage = 18.5m,
                    Price = 99, Description = "Nyanserad smak med inslag av torkad frukt, hasseln�tter, choklad, farinsocker och apelsinskal. Serveras vid cirka 14�C som aperitif eller till kallskuret.",
                    ProductNumber = 8227, AccountingCode = 00200, VatCode = 01, Volume = 375, PackageAmount = 10
                },
                new Product()
                {
                    Id = 31, ProductCategoryId = 9, Name = "El Paseillo Charro", AlcoholPercentage = 40m,
                    Price = 399, Description = "Nyanserad, kryddig smak med tydlig fatkarakt�r, inslag av halm, vanilj, pomerans, �rter och vanilj. Serveras rumstempererad som digestif.",
                    ProductNumber = 568, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 8
                },
                new Product()
                {
                    Id = 32, ProductCategoryId = 9, Name = "Patr�n", AlcoholPercentage = 40m,
                    Price = 699, Description = "Nyanserad smak med fatkarakt�r, inslag av f�rska �rter, macadamian�tter, p�ron, halm och citrusskal. Serveras rumstempererad som digestif.",
                    ProductNumber = 86940, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 8
                },
                new Product()
                {
                    Id = 33, ProductCategoryId = 9, Name = "Sierra Tequila Silver", AlcoholPercentage = 38m,
                    Price = 199, Description = "Robust smak med inslag av gr�s och citrusskal. Anv�nds som drinkingrediens.",
                    ProductNumber = 307, AccountingCode = 00200, VatCode = 01, Volume = 700, PackageAmount = 10
                },
                new Product()
                {
                    Id = 34, ProductCategoryId = 10, Name = "Blossa Starkvinsgl�gg", AlcoholPercentage = 38m,
                    Price = 83, Description = "Kryddig, mycket s�t smak med inslag av kryddnejlika, ingef�ra, russin och kanel.",
                    ProductNumber = 8505, AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 8
                },
                new Product()
                {
                    Id = 35, ProductCategoryId = 10, Name = "Dufvenkrooks Julspecial", AlcoholPercentage = 20m,
                    Price = 95, Description = "S�t, kryddig smak med inslag av ingef�ra, muskot, kardemumma, r�da �pplen, pomerans, torkad frukt och �rter.",
                    ProductNumber = 30409, AccountingCode = 00200, VatCode = 01, Volume = 500, PackageAmount = 8
                },
                new Product()
                {
                    Id = 36, ProductCategoryId = 10, Name = "Grythyttan Skogsgl�gg", AlcoholPercentage = 14.5m,
                    Price = 91, Description = "Kryddig, s�t smak med inslag av lingon, bl�b�r, kanel, kryddnejlika, pomerans och ingef�ra.",
                    ProductNumber = 96460, AccountingCode = 00200, VatCode = 01, Volume = 750, PackageAmount = 6
                },

#endregion
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
