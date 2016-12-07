namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AdressId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AdressId, cascadeDelete: true)
                .Index(t => t.AdressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "AdressId", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "AdressId" });
            DropTable("dbo.Contacts");
        }
    }
}
