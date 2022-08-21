using Microsoft.AspNetCore.Mvc;

namespace ContactList.Server.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult GetAllContacts()
        {
            return Ok(_service.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
                return NotFound("No such contact found");

            return Ok(contact);
        }
    }
}
