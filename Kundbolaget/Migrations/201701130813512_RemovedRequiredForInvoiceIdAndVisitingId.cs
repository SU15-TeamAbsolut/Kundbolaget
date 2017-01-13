namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredForInvoiceIdAndVisitingId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "InvoiceAddressId" });
            AlterColumn("dbo.Customers", "InvoiceAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "InvoiceAddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "InvoiceAddressId" });
            AlterColumn("dbo.Customers", "InvoiceAddressId", c => c.Int());
            CreateIndex("dbo.Customers", "InvoiceAddressId");
        }
    }
}
