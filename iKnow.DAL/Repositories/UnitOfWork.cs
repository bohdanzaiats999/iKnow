using iKnow.DAL.EF;
using iKnow.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace iKnow.DAL.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed;
        private readonly IKnowContext context;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        private Dictionary<string, object> repositories;
        public void SaveChanges() => context.SaveChanges();
        public UnitOfWork() => context = new IKnowContext();
        public UserRepository<T> UserRepository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(UserRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (UserRepository<T>)repositories[type];
        }

        public UnitOfWork(IKnowContext context) => this.context = context;
        public ExcerciseRepository<T> ExcerciseRepository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(ExcerciseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (ExcerciseRepository<T>)repositories[type];
        }
    }
}
