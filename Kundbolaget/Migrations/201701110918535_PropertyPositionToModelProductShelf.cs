namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyPositionToModelProductShelf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductShelves", "Position", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductShelves", "Position");
        }
    }
}
