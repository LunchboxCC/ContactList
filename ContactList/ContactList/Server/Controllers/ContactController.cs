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
        public IActionResult GetContactById(long id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
                return NotFound("No such contact found");

            return Ok(contact);
        }

        [HttpPost("add")]
        public IActionResult PostNewContact(Contact contact)
        {
            var result = _service.AddNewContact(contact);

            return result == true ? Ok("Contact added") : BadRequest("Contact not added");
        }

        [HttpPost("edit")]
        public IActionResult PostEditContact(Contact contact)
        {
            var result = _service.EditContact(contact);

            return result == true ? Ok("Contact edited") : BadRequest("Contact not edited");
        }

        [HttpDelete("delete")]
        public IActionResult DeleteSingleContact(long id)
        {
            var result = _service.DeleteContact(id);

            return result == true ? Ok("Contact deleted") : BadRequest("Contact not deleted");
        }
    }
}
