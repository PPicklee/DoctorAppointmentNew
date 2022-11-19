using DoctorAppointment.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services Container
var connectionString = builder.Configuration.GetConnectionString("DoctorAppointmentContext");
builder.Services.AddDbContext<DoctorAppointmentContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DoctorAppointmentContext>();
builder.Services.AddControllersWithViews();

// enable Google auth, reading keys from appsettings.json or Azure Config section
//builder.Services.AddAuthentication()
//    .AddGoogle(options =>
//    {
//        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//    });
// Support for session
builder.Services.AddSession();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// enable sessions
app.UseSession();
app.Run();