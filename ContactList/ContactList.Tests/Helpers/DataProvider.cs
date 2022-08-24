using ContactList.Server.Database;
using ContactList.Shared;

namespace ContactList.Tests.Helpers
{
    public static class DataProvider
    {
        public static List<Contact> GetListOfSeededContacts()
        {
            return DataSeeder.GetAllSeedingContacts();
        }
    }
}
