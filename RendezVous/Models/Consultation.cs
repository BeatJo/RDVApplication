using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RendezVous.Models
{
    public enum Etat
    {
        ANNULE, TERMINE, EN_COURS, PROGRAMME
    }
    public class Consultation
    {
        [Key]
        public int ConsultationTD { get; set; }
        [Column("medecin_id")]
        public int MedecinID { get; set; }
        [Column("client_id")]
        public int ClientID { get; set; }
        [Display(Name = "Type de consultation")]
        [Column("type_consultation_id")]
        public int TypeConsultationID { get; set; }
        [Required]
        public float Prix { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
        public DateOnly Date { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeOnly Heure { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public Etat Etat { get; set; } = Etat.PROGRAMME;
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Medecin Medecin { get; set; }
        public Client Client { get; set; }
        [Required]
        public TypeConsultation? TypeConsultation { get; set; }
    }
}
