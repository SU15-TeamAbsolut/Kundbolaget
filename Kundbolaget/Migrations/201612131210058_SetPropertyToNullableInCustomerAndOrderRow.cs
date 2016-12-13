namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetPropertyToNullableInCustomerAndOrderRow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses");
            DropForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "InvoiceAddressId" });
            DropIndex("dbo.Customers", new[] { "AlcoholLicenseId" });
            AlterColumn("dbo.Customers", "InvoiceAddressId", c => c.Int());
            AlterColumn("dbo.Customers", "AlcoholLicenseId", c => c.Int());
            AlterColumn("dbo.OrderRows", "AmountShipped", c => c.Int());
            CreateIndex("dbo.Customers", "InvoiceAddressId");
            CreateIndex("dbo.Customers", "AlcoholLicenseId");
            AddForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses", "Id");
            AddForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses");
            DropIndex("dbo.Customers", new[] { "AlcoholLicenseId" });
            DropIndex("dbo.Customers", new[] { "InvoiceAddressId" });
            AlterColumn("dbo.OrderRows", "AmountShipped", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "AlcoholLicenseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "InvoiceAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "AlcoholLicenseId");
            CreateIndex("dbo.Customers", "InvoiceAddressId");
            AddForeignKey("dbo.Customers", "InvoiceAddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses", "Id", cascadeDelete: true);
        }
    }
}
