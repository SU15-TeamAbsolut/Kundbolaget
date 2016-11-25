using System.Data.Entity;
using MVCCMS.Models.EntityModels;

namespace MVCCMS.EntityFramework.Contexts
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}