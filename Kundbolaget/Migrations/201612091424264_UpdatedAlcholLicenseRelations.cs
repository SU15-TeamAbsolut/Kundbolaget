namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAlcholLicenseRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlcoholLicenses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AlcoholLicenses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AlcoholLicenses", new[] { "CustomerId" });
            DropIndex("dbo.AlcoholLicenses", new[] { "AddressId" });
            AddColumn("dbo.Customers", "AlcoholLicenseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "AlcoholLicenseId");
            AddForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses", "Id", cascadeDelete: true);
            DropColumn("dbo.AlcoholLicenses", "CustomerId");
            DropColumn("dbo.AlcoholLicenses", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlcoholLicenses", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.AlcoholLicenses", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "AlcoholLicenseId", "dbo.AlcoholLicenses");
            DropIndex("dbo.Customers", new[] { "AlcoholLicenseId" });
            DropColumn("dbo.Customers", "AlcoholLicenseId");
            CreateIndex("dbo.AlcoholLicenses", "AddressId");
            CreateIndex("dbo.AlcoholLicenses", "CustomerId");
            AddForeignKey("dbo.AlcoholLicenses", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AlcoholLicenses", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
