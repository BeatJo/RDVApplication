using Microsoft.EntityFrameworkCore;
using RendezVous.Data;
using Microsoft.AspNetCore.Identity;
using RendezVous.Utils;
using RendezVous.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RDVAppContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddRazorPages();

builder.Services.AddIdentity<Utilisateur, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<RDVAppContext>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

var app = builder.Build();

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
void DataSedding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope
            .ServiceProvider
            .GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }    

}
