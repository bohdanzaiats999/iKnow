using iKnow.DAL.EF;

namespace iKnow.DAL.Repositories
{
    public class ExcerciseRepository<T> : Repository<T> where T : class
    {
        public ExcerciseRepository(IKnowContext context) : base(context) { }

    }
}
