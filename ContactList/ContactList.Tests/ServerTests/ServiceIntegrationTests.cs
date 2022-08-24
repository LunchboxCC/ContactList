using ContactList.Server.Database;
using ContactList.Tests.Helpers;
using Newtonsoft.Json;

namespace ContactList.Tests.ServerTests
{
    public class ServiceIntegrationTests
    {
        private readonly IContactService _service;
        private readonly ApplicationContext _context;

        public ServiceIntegrationTests()
        {
            _context = TestingContextProvider.CreateContext();
            _service = new ContactService(_context);
        }

        [Fact]
        public void GetAllContactsGetsSeededContacts()
        {
            var expectedContacts = DataProvider.GetListOfContacts();

            var actualContacts = _service.GetAllContacts();

            Assert.Equal(expectedContacts.Count, actualContacts.Count);
            Assert.Equal(JsonConvert.SerializeObject(expectedContacts), JsonConvert.SerializeObject(actualContacts));
        }

        [Fact]
        public void DeleteContactRemovesContactFromDatabase()
        {
            var contactList = _context.Contacts.ToList();
            var contactCount = contactList.Count;
            var contactIdToDelete = contactList.ElementAt(2).ContactId;

            var result = _service.DeleteContact(contactIdToDelete);
            var contactListAfterDeletion = _context.Contacts.ToList();

            Assert.True(result);
            Assert.Equal(contactCount - 1, contactListAfterDeletion.Count());
            Assert.False(contactListAfterDeletion.Any(c => c.ContactId == contactIdToDelete));
        }
    }
}
