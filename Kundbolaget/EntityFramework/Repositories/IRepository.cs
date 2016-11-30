using System.Collections;
using System.Collections.Generic;

namespace Kundbolaget.EntityFramework.Repositories
{
    public interface IRepository<T>
    {
        T Find(int id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}