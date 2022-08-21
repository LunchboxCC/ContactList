using ContactListRazorViews.Models;
using ContactListRazorViews.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactListRazorViews.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Contact> contacts = _service.GetAllContacts();
            return View("~/Pages/List.cshtml", contacts);
        }

        [HttpGet("{contactId}/edit")]
        public IActionResult EditContact(int contactId)
        {
            Contact contact = _service.GetContactById(contactId);
            if (contact == null)
                return View("Error");

            return View("~/Views/ContactEdit.cshtml", contact);
        }

        [HttpGet("/test")]
        public IActionResult EditContactTest()
        {
            Contact contact = _service.GetContactById(1);
            if (contact == null)
                return View("Error");

            return View("~/Views/TestEdit.cshtml", contact);
        }
    }
}
