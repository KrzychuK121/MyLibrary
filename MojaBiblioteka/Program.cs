using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MojaBiblioteka.Data;
using MojaBiblioteka.Data.Seeds;
using MojaBiblioteka.Models.Entities.Persons;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyLibraryContext") ?? throw new InvalidOperationException("Connection string 'MyLibraryContext' not found.")));

builder.Services.AddDefaultIdentity<User>(
    options => options.SignIn.RequireConfirmedAccount = true
)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<MyLibraryContext>();

builder.Services.AddScoped<PasswordHasher<User>>();

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Enable database initialization
    SeedDatabase databaseSeeder = new SeedDatabase(services);
    databaseSeeder.Initialize();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
