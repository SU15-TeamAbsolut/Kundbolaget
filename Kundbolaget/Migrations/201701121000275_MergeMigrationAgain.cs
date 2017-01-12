namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergeMigrationAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlcoholLicenses", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductShelfChangeLogs", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.ProductShelves", "Position", c => c.String(nullable: false));
            DropColumn("dbo.AlcoholLicenses", "IsValid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlcoholLicenses", "IsValid", c => c.Boolean(nullable: false));
            DropColumn("dbo.ProductShelves", "Position");
            DropColumn("dbo.ProductShelfChangeLogs", "Amount");
            DropColumn("dbo.AlcoholLicenses", "IsActive");
        }
    }
}
