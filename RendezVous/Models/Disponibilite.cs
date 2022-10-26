using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace RendezVous.Models
{
    public enum JourDeLaSemaine
    {
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
        Dimanche
    }

    public class Disponibilite
    {
        [Key]
        public int DisponibiliteID { get; set; }
        [Required]
        [Display(Name = "Jour de la semaine")]
        public JourDeLaSemaine JourDeLaSemaine { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Heure de Debut")]
        public DateTime HeureDebut { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Heure de Fin")]
        public DateTime HeureFin { get; set; }

        [Column("medecin_id")]
        public int MedecinID { get; set; }
        public Medecin Medecin { get; set; }
    }
}
