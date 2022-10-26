using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RendezVous.Models;

namespace RendezVous.Data
{
    public class RDVAppContext : IdentityDbContext
    {
        public RDVAppContext(DbContextOptions<RDVAppContext> options) : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

    }
}
