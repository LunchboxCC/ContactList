using ContactList.Shared;
using ContactList.Tests.Helpers;
using Newtonsoft.Json;

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
                Data = DataProvider.GetListOfContacts()
            };

            var response = await _factory.CreateClient().GetAsync($"/api/contacts");
            var jsonString = await response.Content.ReadAsStringAsync();
            var actualContent = JsonConvert.DeserializeObject<ServerResponse<List<Contact>>>(jsonString);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.True(actualContent.Success);
            Assert.Equal(expectedCount, actualContent.Data.Count);

            Assert.Equal(JsonConvert.SerializeObject(expectedContent), JsonConvert.SerializeObject(actualContent));
        }
    }
}
