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
            DataSeeder.SeedDatabase(modelBuilder);
        }
    }
}
