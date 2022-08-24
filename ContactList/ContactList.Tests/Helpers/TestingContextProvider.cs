using ContactList.Server.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Tests.Helpers
{
    public class TestingContextProvider
    {
        public static ApplicationContext CreateContext()
        {
            var dbConnection = new SqliteConnection("Datasource=:memory:");
            dbConnection.Open();
            var contextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlite(dbConnection).Options;
            var context = new ApplicationContext(contextOptions);

            context.Database.EnsureCreated();

            return context;
        }
    }
}
