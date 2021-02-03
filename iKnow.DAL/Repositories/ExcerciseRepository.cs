using iKnow.DAL.EF;
using iKnow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace iKnow.DAL.Repositories
{
    public class ExcerciseRepository<T> : IRepository<T> where T : class
    {
        private readonly IKnowContext context;
        private readonly DbSet<T> entities;

        public IQueryable<T> Set => this.entities;

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<System.Func<T, object>>[] include)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] include)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
