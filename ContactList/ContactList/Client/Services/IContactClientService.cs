using ContactList.Shared;

namespace ContactList.Client.Services
{
    public interface IContactClientService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetSingleContact(long id);
        Task<Contact> AddNewContact(Contact newContact);
        Task<bool> EditContact(Contact contact);
        Task DeleteSingleContact(long id);
    }
}
