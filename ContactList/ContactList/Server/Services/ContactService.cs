using ContactList.Server.Database;

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

    public Contact? GetContactById(long id)
    {
        return _context.Contacts.FirstOrDefault(c => c.ContactId == id);
    }

    public bool AddNewContact(Contact newContact)
    {
        _context.Contacts.Add(newContact);
        var result = _context.SaveChanges();

        return result == 1 ? true : false;
    }

    public bool EditContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        var result = _context.SaveChanges();

        return result == 1 ? true : false;
    }

    public bool DeleteContact(long id)
    {
        var entity = GetContactById(id);
        if (entity == null)
            return false;

        _context.Contacts.Remove(entity);
        var result = _context.SaveChanges();

        return result == 1 ? true : false;
    }
}