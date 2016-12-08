namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldPackageAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PackageAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PackageAmount");
        }
    }
}
