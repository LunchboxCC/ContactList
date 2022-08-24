using Microsoft.EntityFrameworkCore;

namespace ContactList.Server.Database
{
    public static class DataSeeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(GetAllSeedingContacts());
        }

        public static List<Contact> GetAllSeedingContacts()
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
                PhoneNumber = "+44 128 478 888"
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
