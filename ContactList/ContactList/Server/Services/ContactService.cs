using ContactList.Server.Database;
using ContactList.Shared;

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
}