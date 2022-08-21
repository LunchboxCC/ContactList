using ContactListRazorViews.Database;
using ContactListRazorViews.Models;
using ContactListRazorViews.Services.Interfaces;

namespace ContactListRazorViews.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationContext _context;

        public ContactService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }

        public Contact? GetContactById(int contactId)
        {
            return _context.Contacts.FirstOrDefault(c => c.ContactId == contactId);
        }
    }
}
