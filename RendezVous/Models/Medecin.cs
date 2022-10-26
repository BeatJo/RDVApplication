using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RendezVous.Models
{
    public class Medecin : Utilisateur
    {
        public int Matricule { get; set; }
        [Column("specialite_id")]
        public int SpecialiteID { get; set; }
        public Specialite Specialite { get; set; }
        [StringLength(50)]
        public ICollection<Consultation>? Consultations { get; set; }
        public ICollection<Disponibilite>? Disponibilites { get; set; }
    }
}
