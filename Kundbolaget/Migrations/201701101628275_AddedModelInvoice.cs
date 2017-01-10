namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelInvoice : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "InvoiceId" });
            AlterColumn("dbo.Orders", "InvoiceId", c => c.Int());
            CreateIndex("dbo.Orders", "InvoiceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "InvoiceId" });
            AlterColumn("dbo.Orders", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "InvoiceId");
        }
    }
}
