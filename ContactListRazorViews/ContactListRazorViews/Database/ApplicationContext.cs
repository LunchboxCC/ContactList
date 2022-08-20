using ContactListRazorViews.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ContactListRazorViews.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationContext()
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

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
                });
        }
    }
}
