using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RendezVous.Models
{
    public class Utilisateur : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
        [StringLength(50)]
        public string? Prenom { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string NomTotal
        {
            get
            {
                return Nom + ", " + Prenom;
            }

        }
    }
}
