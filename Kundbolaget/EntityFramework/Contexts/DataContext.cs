using System.Data.Entity;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AlcoholLicense> AlcoholLicenses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}