
namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Kundbolaget.Models.EntityModels;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kundbolaget.EntityFramework.Contexts.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kundbolaget.EntityFramework.Contexts.DataContext context)
        {
            Supplier[] suppliers =
            {
                new Supplier { Name = "Bengts Vodka", Email = "bengt@example.net" }
            };

            context.Suppliers.AddOrUpdate(suppliers);
        }
    }
}
