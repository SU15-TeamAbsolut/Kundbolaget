namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCustomerModel : DbMigration
    {
        public override void Up()
        {
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
                        OrganizationNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            // Set starting value for auto-incrementing id to 10000
            // (Next item gets value+1, thus starting at 9999)
            Sql("DBCC CHECKIDENT ('Customers', RESEED, 9999);");
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
