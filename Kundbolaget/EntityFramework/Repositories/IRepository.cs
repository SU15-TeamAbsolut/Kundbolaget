using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);
        IList<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}