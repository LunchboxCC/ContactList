using Microsoft.AspNetCore.Mvc;

namespace ContactList.Server.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet("contacts")]
        public List<Contact> GetAllContacts()
        {
            return _service.GetAllContacts();
        }
    }
}
