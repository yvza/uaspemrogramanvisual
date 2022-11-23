using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcwithlogin.Data;
using mvcwithlogin.Models;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
//manually added by me--
builder.Services.AddMvc();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("server=localhost;database=dotnetuas;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb"))
);
builder.Services.AddDbContext<dotnetuasContext>(options =>
    options.UseMySql("server=localhost;database=dotnetuas;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb"))
);
//manually added by me--
// var connectionString = builder.Configuration.GetConnectionString("MysqlConnection");
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// options.UseMySQL(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
