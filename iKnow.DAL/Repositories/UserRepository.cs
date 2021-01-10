using iKnow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iKnow.DAL.Repositories
{
    class UserRepository<T> : IRepository<T> where T : class
    {
        public IQueryable<T> Set => throw new NotImplementedException();

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
