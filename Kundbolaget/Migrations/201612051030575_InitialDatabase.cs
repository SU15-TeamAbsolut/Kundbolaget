namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
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
            // Set initial auto-increment value to 10000
            Sql("DBCC CHECKIDENT ('Customers', RESEED, 10000);");

            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
            DropTable("dbo.AlcoholLicenses");
        }
    }
}
