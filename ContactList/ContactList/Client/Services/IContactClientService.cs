using ContactList.Shared;

namespace ContactList.Client.Services
{
    public interface IContactClientService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetSingleContact(long id);
        Task<bool> AddNewContact(Contact newContact);
        Task<bool> EditContact(Contact contact);
        Task<bool> DeleteSingleContact(long id);
    }
}
