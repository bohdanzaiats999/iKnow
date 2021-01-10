using iKnow.DAL.Interfaces;
using System;

namespace iKnow.DAL.Repositories
{
    class UnitOfWork : IDisposable, IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
