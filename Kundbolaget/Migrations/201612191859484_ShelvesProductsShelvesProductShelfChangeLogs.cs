namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShelvesProductsShelvesProductShelfChangeLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductShelfChangeLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Initials = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ShelfId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Shelves", t => t.ShelfId)
                .Index(t => t.ShelfId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.ProductShelves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ShelfId = c.Int(nullable: false),
                        CurrentAmount = c.Int(nullable: false),
                        MinimumAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Shelves", t => t.ShelfId)
                .Index(t => t.ProductId)
                .Index(t => t.ShelfId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductShelves", "ShelfId", "dbo.Shelves");
            DropForeignKey("dbo.ProductShelves", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductShelfChangeLogs", "ShelfId", "dbo.Shelves");
            DropForeignKey("dbo.Shelves", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ProductShelfChangeLogs", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductShelves", new[] { "ShelfId" });
            DropIndex("dbo.ProductShelves", new[] { "ProductId" });
            DropIndex("dbo.Shelves", new[] { "WarehouseId" });
            DropIndex("dbo.ProductShelfChangeLogs", new[] { "ProductId" });
            DropIndex("dbo.ProductShelfChangeLogs", new[] { "ShelfId" });
            DropTable("dbo.ProductShelves");
            DropTable("dbo.Shelves");
            DropTable("dbo.ProductShelfChangeLogs");
        }
    }
}
