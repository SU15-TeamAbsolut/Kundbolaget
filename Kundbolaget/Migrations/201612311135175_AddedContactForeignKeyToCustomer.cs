namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactForeignKeyToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ContactId", c => c.Int());
            CreateIndex("dbo.Customers", "ContactId");
            AddForeignKey("dbo.Customers", "ContactId", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Customers", new[] { "ContactId" });
            DropColumn("dbo.Customers", "ContactId");
        }
    }
}
