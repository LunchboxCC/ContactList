using ContactList.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ContactList.Client.Services
{
    public class ContactClientService : IContactClientService
    {
        private readonly HttpClient _http;

        public ContactClientService(HttpClient client)
        {
            _http = client;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var result = await _http.GetFromJsonAsync<List<Contact>>("api/contacts");

            if (result == null)
                return new List<Contact>();

            return result;
        }

        public async Task<Contact> GetContactById(int id)
        {
            var result = await _http.GetAsync($"api/contacts/{id}");

            if ((int)result.StatusCode == 404)
                return new Contact();

            var contact = await result.Content.ReadFromJsonAsync<Contact>();

            return contact;
        }
    }
}
