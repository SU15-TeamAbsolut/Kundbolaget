namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            RenameColumn(table: "dbo.Addresses", name: "Country_Id", newName: "CountryId");
            RenameColumn(table: "dbo.Products", name: "ProductCategory_Id", newName: "ProductCategoryId");
            RenameIndex(table: "dbo.Addresses", name: "IX_Country_Id", newName: "IX_CountryId");
            AddColumn("dbo.AlcoholLicenses", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.AlcoholLicenses", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "InvoiceAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "VisitingAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Suppliers", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Warehouses", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.AlcoholLicenses", "CustomerId");
            CreateIndex("dbo.AlcoholLicenses", "AddressId");
            CreateIndex("dbo.Customers", "InvoiceAddressId");
            CreateIndex("dbo.Customers", "VisitingAddressId");
            CreateIndex("dbo.Products", "ProductCategoryId");
            CreateIndex("dbo.Suppliers", "AddressId");
            CreateIndex("dbo.Warehouses", "AddressId");
            AddForeignKey("dbo.AlcoholLicenses", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Customers", "VisitingAddressId", "dbo.Addresses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.AlcoholLicenses", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Warehouses", "AddressId", "dbo.Addresses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.Warehouses", "AdressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "AdressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Warehouses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Suppliers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AlcoholLicenses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "VisitingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses");
            DropForeignKey("dbo.AlcoholLicenses", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Warehouses", new[] { "AddressId" });
            DropIndex("dbo.Suppliers", new[] { "AddressId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Customers", new[] { "VisitingAddressId" });
            DropIndex("dbo.Customers", new[] { "InvoiceAddressId" });
            DropIndex("dbo.AlcoholLicenses", new[] { "AddressId" });
            DropIndex("dbo.AlcoholLicenses", new[] { "CustomerId" });
            AlterColumn("dbo.Products", "ProductCategoryId", c => c.Int());
            AlterColumn("dbo.ProductCategories", "Name", c => c.String());
            DropColumn("dbo.Warehouses", "AddressId");
            DropColumn("dbo.Suppliers", "AddressId");
            DropColumn("dbo.Customers", "VisitingAddressId");
            DropColumn("dbo.Customers", "InvoiceAddressId");
            DropColumn("dbo.AlcoholLicenses", "AddressId");
            DropColumn("dbo.AlcoholLicenses", "CustomerId");
            RenameIndex(table: "dbo.Addresses", name: "IX_CountryId", newName: "IX_Country_Id");
            RenameColumn(table: "dbo.Products", name: "ProductCategoryId", newName: "ProductCategory_Id");
            RenameColumn(table: "dbo.Addresses", name: "CountryId", newName: "Country_Id");
            CreateIndex("dbo.Products", "ProductCategory_Id");
            AddForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories", "Id");
        }
    }
}
