using API.Model;
using AutoMapper;
namespace API.Mapper
{
    public class ContactToPartialContactMapper : Profile
    {
        public ContactToPartialContactMapper()
        {
            CreateMap<Contact, PartialContactInformation>();
        }
    }
}
