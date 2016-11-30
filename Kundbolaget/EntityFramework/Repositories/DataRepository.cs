using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class DataRepository<T> : IRepository<T>
    {
        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}