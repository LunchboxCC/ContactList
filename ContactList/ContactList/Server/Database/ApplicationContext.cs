using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContactList.Server.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(x => x.ContactId);

            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    ContactId = 1,
                    FirstName = "Ramza",
                    LastName = "Beoulve",
                    EmailAddress = "beoulve.iv@gmail.com",
                    PhoneNumber = string.Empty
                },
                new Contact()
                {
                    ContactId = 2,
                    FirstName = "Agrias",
                    LastName = "Oaks",
                    EmailAddress = "agrias.oaks@gmail.com",
                    PhoneNumber = "+44 128 478 364"
                },
                new Contact()
                {
                    ContactId = 3,
                    FirstName = "Delita",
                    LastName = "Heiral",
                    EmailAddress = string.Empty,
                    PhoneNumber = "+421 784 364 144"
                },
                new Contact()
                {
                    ContactId = 4,
                    FirstName = "Olan",
                    LastName = "Durai",
                    EmailAddress = "o-d@hotmail.com",
                    PhoneNumber = "+420 608 058 058"
                });
        }
    }
}
