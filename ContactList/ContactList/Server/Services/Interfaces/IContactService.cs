public interface IContactService
{
    List<Contact> GetAllContacts();
    Contact? GetContactById(long id);
    bool AddNewContact(Contact newContact);
    bool EditContact(Contact contact);
    bool DeleteContact(long id);
}