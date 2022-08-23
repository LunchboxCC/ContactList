using AutoMapper;
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
        private readonly IMapper _mapper;

        public ContactController(IContactService service, IValidator<Contact> validator, IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<ServerResponse<List<Contact>>> GetAllContacts()
        {
            var contacts = _service.GetAllContacts();

            if (contacts.Count == 0)
                return NotFound(new ServerResponse<List<Contact>>(false, "No contacts could be retrieved", contacts));

            return Ok(new ServerResponse<List<Contact>>(true, "", contacts));
        }

        [HttpGet("{id}")]
        public ActionResult<ServerResponse<Contact>> GetContactById(long id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
                return NotFound(new ServerResponse<Contact>(false, "No contact found"));

            return Ok(new ServerResponse<Contact>(true, "", contact));
        }

        [HttpPost("add")]
        public ActionResult<ServerResponse<bool>> PostNewContact(ContactFormDTO newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);

            if (!_validator.Validate(contact).IsValid)
                return BadRequest(new ServerResponse<bool>(false, "Contact info invalid"));

            var result = _service.AddNewContact(contact);

            if (result)
                return Ok(new ServerResponse<bool>(true, "Contact added"));
            else
                throw new Exception("Contact saving failure");
        }

        [HttpPut("edit")]
        public ActionResult<ServerResponse<bool>> PutEditContact(Contact contact)
        {
            if (!_validator.Validate(contact).IsValid)
                return BadRequest(new ServerResponse<bool>(false, "Contact info invalid"));

            var result = _service.EditContact(contact);

            if (result)
                return Ok(new ServerResponse<bool>(true, "Contact edited"));
            else
                throw new Exception("Contact editing failure");
        }

        [HttpDelete("delete")]
        public ActionResult<ServerResponse<bool>> DeleteSingleContact(long id)
        {
            var result = _service.DeleteContact(id);

            if (result)
                return Ok(new ServerResponse<bool>(true, "Contact deleted"));
            else
                throw new Exception("Contact deletion failure");
        }
    }
}
