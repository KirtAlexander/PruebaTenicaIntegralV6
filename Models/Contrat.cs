
using System.ComponentModel.DataAnnotations;

namespace ApiContrats.Models

    {
    public class Contrat
    {
        public Guid ContratId { get; set; }

        [Required(ErrorMessage = "Validity field is required")]
        [Display(Name = "Vigencia")]
        public DateTime Validity { get; set; }


        [Required(ErrorMessage = "Entity field is required")]
        [Display(Name = "Entidad")]
        public string Entity { get; set; }
    }
}

