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

    public Contact? GetContactById(int id)
    {
        return _context.Contacts.FirstOrDefault(c => c.ContactId == id);
    }

    public bool AddNewContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        var result = _context.SaveChanges();

        return result == 1 ? true : false;
    }

    public bool EditContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        var result = _context.SaveChanges();

        return result == 1 ? true : false;
    }
}