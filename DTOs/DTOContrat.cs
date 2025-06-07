using System.ComponentModel.DataAnnotations;

namespace ApiContrats.DTOs
{
    public class ContratCreateDto
    {
        [Required(ErrorMessage = "Validity field is required")]
        [Display(Name = "Vigencia")]
        [CustomValidation(typeof(ContratCreateDto), nameof(ValidateValidityYear))]
        public DateTime Validity { get; set; }
        [Required(ErrorMessage = "Entity field is required")]
        [Display(Name = "Entidad")]
        public string Entity { get; set; }

        public static ValidationResult ValidateValidityYear(DateTime validity, ValidationContext context)
        {
            if (validity.Year < 2020 || validity.Year > 2025)
            {
                return new ValidationResult("El campo Vigencia (año) debe estar entre 2020 y 2025.", new[] { nameof(Validity) });
            }
            return ValidationResult.Success;
        }
    }

    public class ContratResponseDto
    {
        public string Entity { get; set; }
        public string Validity { get; set; }  
        public Guid ContratId { get; set; }
    }
}