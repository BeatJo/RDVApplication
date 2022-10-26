using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RendezVous.Models
{
    public class Specialite
    {
        [Key]
        public int SpecialiteID { get; set; }
        [Required]
        [Column("Nom_de_specialite")]
        public string NomSpecialite { get; set; }
        public ICollection<Medecin>? Medecins { get; set; }
        public ICollection<TypeConsultation>? TypeConsultations { get; set; }
    }
}
