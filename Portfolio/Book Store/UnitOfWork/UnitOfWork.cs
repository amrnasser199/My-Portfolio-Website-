using Book_Store.Repository;
using Core.Interfaces;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AmrContext _context;
        private IGenericRepository<T> _entity;

        public UnitOfWork(AmrContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(_context));
            }
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
