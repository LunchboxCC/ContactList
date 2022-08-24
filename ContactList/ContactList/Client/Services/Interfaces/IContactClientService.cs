namespace ContactList.Client.Services.Interfaces
{
    public interface IContactClientService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetSingleContact(long id);
        Task<BoolMessage> AddNewContact(ContactFormDTO newContact);
        Task<BoolMessage> EditContact(Contact contact);
        Task<BoolMessage> DeleteSingleContact(long id);
    }
}
