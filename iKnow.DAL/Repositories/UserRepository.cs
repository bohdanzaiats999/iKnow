using iKnow.DAL.EF;
using iKnow.DAL.Entityes;
using System.Collections.Generic;
using System.Linq;

namespace iKnow.DAL.Repositories
{
    public class UserRepository<T> : Repository<T> where T : class
    {
        public UserRepository(IKnowContext context) : base(context) { }
        public IList<EmailEntity> GetAllEmails()
        {
            return this.context.Emails.ToList();
        }
        public IEnumerable<T> GetAll() => this.entities.ToList();
        public UserEntity GetByLogin(string login) => this.context.Users.FirstOrDefault(u => u.Login == login);
    }
}
