global using ContactList.Shared;
global using ContactList.Shared.Models;
using ContactList.Server.Database;
using ContactList.Server.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

ConfigureDatabase(builder);
ConfigureServices(builder.Services);
ConfigureSwagger(builder.Services);
ConfigureAutoMapper(builder.Services);

var app = builder.Build();

CreateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IContactService, ContactService>();
    services.AddScoped<IValidator<Contact>, ContactValidator>();
}

static void ConfigureDatabase(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DevConnection");
    builder.Services.AddDbContext<ApplicationContext>(b => b.UseSqlServer(connectionString));
}

static void CreateDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        if (!context.Database.CanConnect())
        {
            context.Database.Migrate();
        }
    }
}

static void ConfigureSwagger(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Contact list app",
            Description = "Interview homework"
        });
    });
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(Program).Assembly);
}

public partial class Program { }