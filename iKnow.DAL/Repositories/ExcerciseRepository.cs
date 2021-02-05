using iKnow.DAL.EF;
using iKnow.DAL.Entityes;
using System.Linq;

namespace iKnow.DAL.Repositories
{
    public class ExcerciseRepository<T> : Repository<T> where T : class
    {
        public ExcerciseRepository(IKnowContext context) : base(context) { }

        public ExcerciseEntity GetByName(string name) => this.context.Excercises.FirstOrDefault(n => n.Name == name);
    }
}
