namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        ZipNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.CountryId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AlcoholLicenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AdressId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AdressId)
                .Index(t => t.AdressId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(),
                        CreditLine = c.Int(nullable: false),
                        PaymentTerm = c.Int(nullable: false),
                        AccountingCode = c.Int(nullable: false),
                        OrganizationNumber = c.Long(nullable: false),
                        InvoiceAddressId = c.Int(),
                        VisitingAddressId = c.Int(nullable: false),
                        AlcoholLicenseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlcoholLicenses", t => t.AlcoholLicenseId)
                .ForeignKey("dbo.Addresses", t => t.InvoiceAddressId)
                .ForeignKey("dbo.Addresses", t => t.VisitingAddressId)
                .Index(t => t.InvoiceAddressId)
                .Index(t => t.VisitingAddressId)
                .Index(t => t.AlcoholLicenseId);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        AmountOrdered = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountShipped = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ShippingAddressId = c.Int(nullable: false),
                        OrderPlaced = c.DateTime(nullable: false),
                        DesiredDeliveryDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddressId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShippingAddressId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductNumber = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                        PackageAmount = c.Int(nullable: false),
                        AlcoholPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountingCode = c.Int(nullable: false),
                        VatCode = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Warehouses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Suppliers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderRows", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Orders", "ShippingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "VisitingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses");
            DropForeignKey("dbo.Contacts", "AdressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.Warehouses", new[] { "AddressId" });
            DropIndex("dbo.Suppliers", new[] { "AddressId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Orders", new[] { "ShippingAddressId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRows", new[] { "ProductId" });
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropIndex("dbo.Customers", new[] { "AlcoholLicenseId" });
            DropIndex("dbo.Customers", new[] { "VisitingAddressId" });
            DropIndex("dbo.Customers", new[] { "InvoiceAddressId" });
            DropIndex("dbo.Contacts", new[] { "AdressId" });
            DropIndex("dbo.Addresses", new[] { "Customer_Id" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Customers");
            DropTable("dbo.Contacts");
            DropTable("dbo.AlcoholLicenses");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}
