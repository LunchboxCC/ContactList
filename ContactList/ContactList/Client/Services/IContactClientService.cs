using ContactList.Shared;

namespace ContactList.Client.Services
{
    public interface IContactClientService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
    }
}
