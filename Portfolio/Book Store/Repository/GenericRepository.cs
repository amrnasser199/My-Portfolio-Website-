using Core.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace Book_Store.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AmrContext _context;
        private DbSet<T> Table = null;

        public GenericRepository(AmrContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

       

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }
        public T GetByID(object id)
        {
            return Table.Find(id);
        }

        public void Insert(T entity)
        {
           Table.Add(entity);
        }
        public void Delete(object id)
        {
             T existing=GetByID(id);
            Table.Remove(existing);
        }
        public void Update(T entity)
        {
            Table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
