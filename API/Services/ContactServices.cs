using API.DatabaseContext;
using API.Model;
using API.PasswordFunction;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _context;
        private readonly IMapper _mapper;
        public ContactServices(IContactRepository contactRepository, IMapper mapper) {
            _mapper= mapper;
            _context = contactRepository;
        }

        public async Task<Contact> AddNewContact(Contact contact)
        {

            //Hashowanie hasla 
            contact.Password = PaswordHash.HashPassword(contact.Password);
            //
            var result = await _context.Add(contact);
            await _context.SaveChanges();
            return result;  
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.GetById(id);
            _context.Delete(contact);
            await _context.SaveChanges();
            return true;
        }

        public async Task<Contact> FindContactById(int id)
        {
            return await _context.GetById(id);
        }

        public async Task<IEnumerable<PartialContactInformation>> GetAllContact()
        {
            var contacts = await _context.GetAllContact();
            return _mapper.Map<IEnumerable<PartialContactInformation>>(contacts);
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            contact.Password = PaswordHash.HashPassword(contact.Password);
            var result  = await _context.Update(contact);
            await _context.SaveChanges();
            return result;
        }
    }
}
