
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController
    {
        private  ContactService _contactService;
        public ContactController() 
        {
            _contactService =  new ContactService(); 
        }
        [HttpGet ("Get")]
        public List<Contact> Get()
        {
            return _contactService.GetContact(); 
        }
        [HttpGet("GetByname")] 
        public List<Contact> GetContactByName(string name)
        {
            return _contactService.GetContactByName(name);
        }
        [HttpPost("Add")] 
        public bool Add(Contact contact)
        {
            return _contactService.AddContact(contact);
        }
        [HttpPut("Update")]
        public bool Update(Contact contact)
        {
            return _contactService.UpdateContact(contact);
        }

        [HttpDelete("Delete")]  
        public void Delete(int id)
        {
            _contactService.DeleteContact(id);
        }
    }
}
