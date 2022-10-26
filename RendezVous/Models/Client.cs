using System.ComponentModel.DataAnnotations;

namespace RendezVous.Models
{
    public class Client : Utilisateur
    {
        public ICollection<Consultation>? Consultations { get; set; }
    }
}
