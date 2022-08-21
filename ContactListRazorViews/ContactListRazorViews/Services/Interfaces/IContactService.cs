using ContactListRazorViews.Models;

namespace ContactListRazorViews.Services.Interfaces
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact? GetContactById(int contactId);
    }
}
