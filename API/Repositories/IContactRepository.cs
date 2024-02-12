using API.Model;
using System.Linq.Expressions;

namespace API.Repositories
{
    public interface IContactRepository 
    {
        Task<Contact> Add(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<IEnumerable<Contact>> GetAllContact();
        Task<Contact> GetById(int id);
        Task SaveChanges();
        void Delete(Contact contac);
        Task<Contact> GetByQuery(Expression<Func<Contact, bool>> query);
    }
}
