public interface IContactService
{
    List<Contact> GetAllContacts();
    Contact? GetContactById(long id);
    bool AddNewContact(Contact contact);
    bool EditContact(Contact contact);
    bool DeleteContact(long id);
}