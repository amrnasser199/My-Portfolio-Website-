using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetByID(Object id);
        void Update(T entity);
        void Delete(object id);
        void Insert(T entity);
        
    }
}
