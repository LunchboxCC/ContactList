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

        public async Task<Contact> GetSingleContact(long id)
        {
            var result = await _http.GetAsync($"api/contacts/{id}");

            if ((int)result.StatusCode == 404)
                throw new Exception("Contact not found");

            return await result.Content.ReadFromJsonAsync<Contact>();
        }

        public Task<Contact> AddNewContact(Contact newContact)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditContact(Contact contact)
        {
            var result = await _http.PostAsJsonAsync("api/contacts/edit", contact);

            if ((int)result.StatusCode == 400)
                return false;

            return true;
        }

        public async Task DeleteSingleContact(long id)
        {
            var result = await _http.DeleteAsync($"api/contacts/delete?id={id}");
        }
    }
}
