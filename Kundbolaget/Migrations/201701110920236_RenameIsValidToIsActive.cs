namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIsValidToIsActive : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AlcoholLicenses", name: "IsValid", newName: "IsActive");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AlcoholLicenses", name: "IsActive", newName: "IsValid");
        }
    }
}
