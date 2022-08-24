using ContactList.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Tests.Helpers
{
    public static class DataProvider
    {
        public static List<Contact> GetListOfContacts()
        {
            var list = new List<Contact>();

            list.Add(new Contact()
            {
                ContactId = 1,
                FirstName = "Ramza",
                LastName = "Beoulve",
                EmailAddress = "beoulve.iv@gmail.com",
                PhoneNumber = string.Empty
            });

            list.Add(new Contact()
            {
                ContactId = 2,
                FirstName = "Agrias",
                LastName = "Oaks",
                EmailAddress = "agrias.oaks@gmail.com",
                PhoneNumber = "+44 128 478 364"
            });

            list.Add(new Contact()
            {
                ContactId = 3,
                FirstName = "Delita",
                LastName = "Heiral",
                EmailAddress = string.Empty,
                PhoneNumber = "+421 784 364 144"
            });

            list.Add(new Contact()
            {
                ContactId = 4,
                FirstName = "Olan",
                LastName = "Durai",
                EmailAddress = "o-d@hotmail.com",
                PhoneNumber = "+420 608 058 058"
            });

            return list;
        }
    }
}
