using System.Data.Entity;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<AlcoholLicense> AlcoholLicenses { get; set; }
    }
}