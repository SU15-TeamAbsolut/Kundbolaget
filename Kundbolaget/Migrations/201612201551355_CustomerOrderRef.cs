namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerOrderRef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerOrderRef", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CustomerOrderRef");
        }
    }
}
