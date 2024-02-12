using API.Model;
using API.Services;
using API.Validation;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactServices _contactService; 
        public ContactController(IContactServices contactServices) {
            _contactService= contactServices;
        }

        [HttpGet("getContact"), AllowAnonymous]
        public async Task<IActionResult> ContactList()
        {
            var contacts = await _contactService.GetAllContact();
            return Ok(contacts);
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (await _contactService.FindContactById(id) is null)
            {
                return BadRequest("Contact doesnt exis");
            }
            return Ok(await _contactService.DeleteContact(id));
        }

        [HttpPost("addNewContact")]
        public async Task<IActionResult> AddNewContact([FromBody] Contact contact)
        {
            ContactValidation validations= new ContactValidation();
            var validResult = validations.Validate(contact);
            
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            return Ok(await _contactService.AddNewContact(contact));
        }

        [HttpPut("updateContact")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            ContactValidation validations = new ContactValidation();
            var validResult = validations.Validate(contact);

             if (await _contactService.FindContactById(contact.Id) is  null)
            {
                return BadRequest("Contact with this Id doesnt exist");
            }
            
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }
            return Ok(await _contactService.UpdateContact(contact));    
        }
    }
}
