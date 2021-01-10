using iKnow.DAL.Repositories;

namespace iKnow.DAL.Interfaces
{
    interface IUnitOfWork
    {
        UserRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
