using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RendezVous.Models
{
    public class TypeConsultation
    {
        [Key]
        public int TypeConsultationID { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public float Prix { get; set; }
        [Column("specialite_id")]
        public int SpecialiteID { get; set; }
        public Specialite Specialite { get; set; }
        public ICollection<Consultation>? Consultations { get; set; }
    }
}
