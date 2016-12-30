using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class ContactRepository : DataRepository<Contact>
    {
        public Contact FindbyAddressId(int id)
        {
            using (var db = new DataContext())
            {
                return db.Contacts
                    .SingleOrDefault(x => x.AdressId == id);
            }
        }
    }
}