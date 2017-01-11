namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyAmountToModelProductShelfChangeLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductShelfChangeLogs", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductShelfChangeLogs", "Amount");
        }
    }
}
