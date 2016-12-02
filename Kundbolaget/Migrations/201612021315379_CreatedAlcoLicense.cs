namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAlcoLicense : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlcoholLicenses");
        }
    }
}
