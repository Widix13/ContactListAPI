using API.DatabaseContext;
using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext contactDb)
        {
            _context = contactDb;
        }

        public async Task<Contact> Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public void Delete(Contact contact)
        {   
             _context.Contacts.Remove(contact);
        }

        public async Task<IEnumerable<Contact>> GetAllContact()
        {
            var reult = await _context.Contacts.AsNoTracking().ToListAsync();
            return reult;
        }

        public async Task<Contact> GetById(int id)
        {
            return await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact> GetByQuery(Expression<Func<Contact, bool>> query)
        {
            return await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(query);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

    }
}
