public interface IContactService
{
    List<Contact> GetAllContacts();
    Contact? GetContactById(int id);
}