namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceAdressId = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        InvoiceStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.InvoiceAdressId)
                .Index(t => t.InvoiceAdressId);
            
            AddColumn("dbo.Orders", "InvoiceId", c => c.Int());
            CreateIndex("dbo.Orders", "InvoiceId");
            AddForeignKey("dbo.Orders", "InvoiceId", "dbo.Invoices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "InvoiceAdressId", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "InvoiceAdressId" });
            DropColumn("dbo.Orders", "InvoiceId");
            DropTable("dbo.Invoices");
        }
    }
}
