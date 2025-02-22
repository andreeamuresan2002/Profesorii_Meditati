using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Profesorii_Meditati.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Ad?ug?m serviciile pentru Razor Pages
builder.Services.AddRazorPages();

// Configur?m contextul bazei de date pentru aplica?ia ta
builder.Services.AddDbContext<Profesorii_MeditatiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Profesorii_MeditatiContext")
    ?? throw new InvalidOperationException("Connection string 'Profesorii_MeditatiContext' not found.")));

// Configur?m contextul de Identity pentru autentificare
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIdentityContextConnection")
    ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContextConnection' not found.")));

// Configur?m Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

// Construim aplica?ia
var app = builder.Build();

// Cre?m rolurile ?i utilizatorul implicit
await CreateRolesAndDefaultUser(app);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

// Metoda pentru crearea rolurilor ?i utilizatorului implicit
async Task CreateRolesAndDefaultUser(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        string[] roleNames = { "Admin", "Profesor", "Student" };

        // Cre?m rolurile dac? nu exist?
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }

        // Cre?m un utilizator implicit Admin, dac? nu exist?
        var defaultUserEmail = "admin@profesorii.ro";
        var defaultUserPassword = "Password123!";
        var user = await userManager.FindByEmailAsync(defaultUserEmail);

        if (user == null)
        {
            user = new IdentityUser
            {
                UserName = defaultUserEmail,
                Email = defaultUserEmail
            };

            await userManager.CreateAsync(user, defaultUserPassword);
            await userManager.AddToRoleAsync(user, "Admin"); // Atribuim rolul Admin utilizatorului
        }
    }
}
