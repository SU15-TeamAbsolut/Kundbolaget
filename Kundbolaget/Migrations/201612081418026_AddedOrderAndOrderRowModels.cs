namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderAndOrderRowModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        AmountOrdered = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        AmountShipped = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ShippingAddressId = c.Int(nullable: false),
                        OrderPlaced = c.DateTime(nullable: false),
                        DesiredDeliveryDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddressId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ShippingAddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "ShippingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "ShippingAddressId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRows", new[] { "ProductId" });
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
        }
    }
}
