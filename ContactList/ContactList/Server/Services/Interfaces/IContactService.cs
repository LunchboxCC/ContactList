public interface IContactService
{
    List<Contact> GetAllContacts();
    Contact? GetContactById(int id);
    bool AddNewContact(Contact contact);
    bool EditContact(Contact contact);
}