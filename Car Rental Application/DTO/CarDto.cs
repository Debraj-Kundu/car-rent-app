using SharedLayer.Service;
using System.ComponentModel.DataAnnotations;

namespace Car_Rental_Application.DTO
{
    public class CarDto : DtoBase
    {
        [Required]
        public string VehicalId { get; set; }

        [Required]
        public string Maker { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal RentalPrice { get; set; }

        [Required]
        public bool AvailabilityStatus { get; set; }
    }
}
