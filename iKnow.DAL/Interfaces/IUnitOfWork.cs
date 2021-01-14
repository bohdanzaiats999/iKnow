using iKnow.DAL.Repositories;

namespace iKnow.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
