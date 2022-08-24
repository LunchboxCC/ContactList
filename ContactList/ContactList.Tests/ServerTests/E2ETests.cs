using ContactList.Shared;
using ContactList.Tests.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace ContactList.Tests.ServerTests
{
    public class E2ETests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public E2ETests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllContactsReturns200AndListOfContacts()
        {
            var expectedCount = 4;
            var expectedStatusCode = 200;
            var expectedContent = new ServerResponse<List<Contact>>()
            {
                Success = true,
                Message = "Contacts retrieved successfully",
                Data = DataProvider.GetListOfSeededContacts()
            };

            var response = await _factory.CreateClient().GetAsync($"/api/contacts");
            var jsonString = await response.Content.ReadAsStringAsync();
            var actualContent = JsonConvert.DeserializeObject<ServerResponse<List<Contact>>>(jsonString);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.True(actualContent.Success);
            Assert.Equal(expectedCount, actualContent.Data.Count);

            Assert.Equal(JsonConvert.SerializeObject(expectedContent), JsonConvert.SerializeObject(actualContent));
        }

        [Fact]
        public async Task PutEditContactDoesntAllowEditWithInvalidInfoProvided()
        {
            var expectedStatusCode = 400;
            var expectedContent = new ServerResponse<bool>()
            {
                Success = false,
                Message = "Contact info invalid"
            };
            var editedContact = new Contact()
            {
                ContactId = 2,
                FirstName = "Agrias",
                LastName = "Oaks",
                EmailAddress = "wrong@email",
                PhoneNumber = "+44 128 478 364"
            };

            var response = await _factory.CreateClient().PutAsJsonAsync($"/api/contacts/edit", editedContact);
            var jsonString = await response.Content.ReadAsStringAsync();
            var actualContent = JsonConvert.DeserializeObject<ServerResponse<bool>>(jsonString);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.False(actualContent.Success);
            Assert.Equal(expectedContent.Message, actualContent.Message);
        }

        [Fact]
        public async Task PostNewContactSavesValidNewContact()
        {
            var expectedStatusCode = 200;
            var expectedContent = new ServerResponse<bool>()
            {
                Success = true,
                Message = "Contact added"
            };
            var newContact = new Contact()
            {
                FirstName = "Cidolfus",
                LastName = "Orlandeau",
                EmailAddress = "valid-email@gmail.com",
                PhoneNumber = ""
            };

            var response = await _factory.CreateClient().PostAsJsonAsync($"/api/contacts/add", newContact);
            var jsonString = await response.Content.ReadAsStringAsync();
            var actualContent = JsonConvert.DeserializeObject<ServerResponse<bool>>(jsonString);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.True(actualContent.Success);
            Assert.Equal(expectedContent.Message, actualContent.Message);
        }
    }
}
