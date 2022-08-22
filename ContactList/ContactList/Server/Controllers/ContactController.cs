using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Server.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IValidator<Contact> _validator;

        public ContactController(IContactService service, IValidator<Contact> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet("")]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            return Ok(_service.GetAllContacts());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(long id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
                return NotFound("No such contact found");

            return Ok(contact);
        }

        [HttpPost("add")]
        public ActionResult<bool> PostNewContact(Contact contact)
        {
            if (!_validator.Validate(contact).IsValid)
                return BadRequest("Contact info invalid");

            var result = _service.AddNewContact(contact);

            return result == true ? Ok("Contact added") : BadRequest("Contact not added");
        }

        [HttpPost("edit")]
        public ActionResult<bool> PostEditContact(Contact contact)
        {
            if (!_validator.Validate(contact).IsValid)
                return BadRequest("Contact info invalid");

            var result = _service.EditContact(contact);

            return result == true ? Ok("Contact edited") : BadRequest("Contact not edited");
        }

        [HttpDelete("delete")]
        public ActionResult<bool> DeleteSingleContact(long id)
        {
            var result = _service.DeleteContact(id);

            return result == true ? Ok("Contact deleted") : BadRequest("Contact not deleted");
        }
    }
}
