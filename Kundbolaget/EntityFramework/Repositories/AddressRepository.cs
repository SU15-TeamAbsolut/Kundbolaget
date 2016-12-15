using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using System.Data.Entity;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class AddressRepository : DataRepository<Address>
    {
        public List<Supplier> GetSuppliersWithAddresses()
        {
            using (var db = new DataContext())
            {
                var suppliers = db.Suppliers
                    .Include(a => a.Address).ToList();

                return suppliers;
            }
        }
        public Supplier GetSupplierWithAddresses(int id)
        {
            using (var db = new DataContext())
            {
                var supplier = db.Suppliers
                    .Include(a => a.Address)
                    .Include(c => c.Address.Country)
                    .SingleOrDefault(x => x.Id == id);
                    

                return supplier;
            }
        }
        public  Warehouse GetWarehouseWithAddress(int id)
        {

            using (var db = new DataContext())
            {
                var model = db.Warehouses
                    .Include(w => w.Address)
                    .Include(c => c.Address.Country)
                    .SingleOrDefault(w => w.Id == id);

                return model;
            }

        }
        public List<Warehouse> GetWarehousesWithAddress()
        {

            using (var db = new DataContext())
            {
                var warehouses = db.Warehouses
                    .Include(w => w.Address)
                    .Include(c => c.Address.Country).ToList();
                  

                return warehouses;
            }

        }

    }
}