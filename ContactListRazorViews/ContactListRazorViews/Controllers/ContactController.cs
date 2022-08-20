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
    }
}
