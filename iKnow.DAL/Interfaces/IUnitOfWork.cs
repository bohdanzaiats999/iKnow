using iKnow.DAL.Repositories;

namespace iKnow.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository<T> UserRepository<T>() where T : class;
        ExcerciseRepository<T> ExcerciseRepository<T>() where T : class;
        void SaveChanges();
    }
}
