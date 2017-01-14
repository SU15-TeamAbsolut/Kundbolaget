namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergeInvoiceThingies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "CustomerId");
            AddForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropColumn("dbo.Invoices", "CustomerId");
        }
    }
}
