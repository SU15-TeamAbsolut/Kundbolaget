using MVCCMS.Models.EntityModels;

namespace MVCCMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCCMS.EntityFramework.Contexts.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCCMS.EntityFramework.Contexts.StoreContext context)
        {
            var products = new Product[]
            {
                new Product {Id = 1, Name = "Product 1", Price = 100},
                new Product {Id = 2, Name = "Product 2", Price = 150},
                new Product {Id = 3, Name = "Product 3", Price = 125},
                new Product {Id = 4, Name = "Product 4", Price = 17.79},
            };

            context.Products.AddOrUpdate(products);
        }
    }
}
