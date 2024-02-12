using API.Model;

namespace API.Services
{
    public interface IContactServices
    {
        public Task<IEnumerable<PartialContactInformation>> GetAllContact();
        public Task<Contact> AddNewContact(Contact contact);
        public Task<Contact> FindContactById(int id);
        public Task<Contact> UpdateContact(Contact contact);
        public Task<bool> DeleteContact(int id);
    }
}
