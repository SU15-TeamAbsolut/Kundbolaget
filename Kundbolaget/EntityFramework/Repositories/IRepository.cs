using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public interface IRepository
    {
        Supplier Find(int id);
        IList<Supplier> GetAll();
        void Create(Supplier item);
        void Update(Supplier item);
        void Delete(int id);
    }
}