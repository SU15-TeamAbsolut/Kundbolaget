namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierAddIsActiveBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "IsActive", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IsActive");
        }
    }
}
