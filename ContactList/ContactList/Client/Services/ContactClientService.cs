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
            var result = await _http.GetFromJsonAsync<ServerResponse<List<Contact>>>("api/contacts");
            if (result == null || result.Data == null)
                throw new Exception("Error occured while fetching contacts");

            return result.Data;
        }

        public async Task<Contact> GetSingleContact(long id)
        {
            var result = await _http.GetFromJsonAsync<ServerResponse<Contact>>($"api/contacts/{id}");

            if (result == null || !result.Success)
                throw new Exception("Contact not found");

            return result.Data;
        }

        public async Task<bool> AddNewContact(Contact newContact)
        {
            //var result = await _http.PostAsJsonAsync("api/contacts/add", newContact);
            var result = await _http.PostAsJsonAsync("api/contacts/add", newContact);

            if (result == null)
                throw new Exception("Contact adding failure");

            var content = await result.Content.ReadFromJsonAsync<ServerResponse<bool>>();
            return content.Success ? true : false;
        }

        public async Task<bool> EditContact(Contact contact)
        {
            var result = await _http.PutAsJsonAsync("api/contacts/edit", contact);

            if (result == null)
                throw new Exception("Contact editing failure");

            var content = await result.Content.ReadFromJsonAsync<ServerResponse<bool>>();
            return content.Success ? true : false;
        }

        public async Task<bool> DeleteSingleContact(long id)
        {
            var result = await _http.DeleteAsync($"api/contacts/delete?id={id}");

            if (result == null)
                throw new Exception("Contact deleting failure");

            var content = await result.Content.ReadFromJsonAsync<ServerResponse<bool>>();
            return content.Success ? true : false;
        }
    }
}
