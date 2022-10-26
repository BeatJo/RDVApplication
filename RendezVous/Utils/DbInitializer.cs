using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RendezVous.Data;
using RendezVous.Models;

namespace RendezVous.Utils
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<Utilisateur> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private RDVAppContext _context;

        public DbInitializer(
            UserManager<Utilisateur> userManager, 
            RoleManager<IdentityRole> roleManager, 
            RDVAppContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }

            }
            catch (Exception)
            {

                throw;
            }
            if (!_roleManager
                .RoleExistsAsync(WebsiteRoles.RDV_Admin)
                .GetAwaiter()
                .GetResult())
            {
                _roleManager
                    .CreateAsync(new IdentityRole(WebsiteRoles.RDV_Admin))
                    .GetAwaiter()
                    .GetResult();
                _roleManager
                    .CreateAsync(new IdentityRole(WebsiteRoles.RDV_Client))
                    .GetAwaiter()
                    .GetResult();
                _roleManager
                    .CreateAsync(new IdentityRole(WebsiteRoles.RDV_Medecin))
                    .GetAwaiter()
                    .GetResult();
                _userManager
                    .CreateAsync(new Utilisateur
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        Nom = "Admin",
                    }, "Admin@123");
                Utilisateur user = _context
                    .Utilisateurs
                    .FirstOrDefault(x => x.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, WebsiteRoles.RDV_Admin);
            }
        }
    }
}
