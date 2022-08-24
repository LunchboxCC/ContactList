using ContactList.Server.Database;

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
