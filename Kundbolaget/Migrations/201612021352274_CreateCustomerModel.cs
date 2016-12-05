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
                        OrganizationNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            // Set initial value for auto-inc Id
            Sql("DBCC CHECKIDENT ('Customers', RESEED, 10000);");
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
