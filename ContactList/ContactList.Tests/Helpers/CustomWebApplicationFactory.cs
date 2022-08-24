using ContactList.Server.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace ContactList.Tests.Helpers
{
    public class CustomWebApplicationFactory : WebApplicationFactory<ContactList.Server.Controllers.ContactController>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var connection = new SqliteConnection("Datasource=:memory:");
            connection.Open();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<ApplicationContext>));
                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseSqlite(connection);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            });

            return base.CreateHost(builder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
