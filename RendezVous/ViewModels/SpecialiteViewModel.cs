using RendezVous.Models;
using System.ComponentModel.DataAnnotations;

namespace RendezVous.ViewModels
{
    public class SpecialiteViewModel
    {
        [Required]
        public string NomSpecialite { get; set; }
        public ICollection<Medecin>? Medecins { get; set; }
        public ICollection<TypeConsultation>? TypeConsultations { get; set; }
    }
}
