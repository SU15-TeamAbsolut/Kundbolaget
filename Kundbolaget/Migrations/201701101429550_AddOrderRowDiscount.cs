namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderRowDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRows", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderRows", "Discount");
        }
    }
}
