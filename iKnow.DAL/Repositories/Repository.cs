using iKnow.DAL.EF;
using iKnow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace iKnow.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private protected readonly DbSet<T> entities;
        private protected readonly IKnowContext context;
        public Repository(IKnowContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is empty");
            }
            this.entities.Remove(entity);
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is empty");
            }
            this.context.SaveChanges();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is empty");
            }
            this.entities.Add(entity);
        }
        public void DeleteById(object id)
        {
            T entityToDelete = this.entities.Find(id);

            if (entityToDelete == null)
            {
                throw new ArgumentNullException("Entity is empty");
            }
            this.entities.Remove(entityToDelete);
        }
        public IQueryable<T> Set => this.entities;
        public void RemoveRange(IQueryable<T> entities)
        {
            foreach (var entity in entities.ToList())
            {
                this.context.Entry(entity).State = EntityState.Deleted;
            }
        }
        public T GetById(object id) => this.entities.Find(id);
        public IQueryable<T> Include(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = this.entities;
            return include.Aggregate(query, (current, inc) => current.Include(inc));
        }
        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = this.entities;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }







    }
}
