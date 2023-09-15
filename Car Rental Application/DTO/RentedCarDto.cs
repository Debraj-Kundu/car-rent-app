using BuisnessLayer.Domain;
using SharedLayer.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_Application.DTO
{
    public class RentedCarDto : DtoBase
    {
        public int UserId { get; set; }
        public UserDto? UserDto { get; set; }
        public int CarId { get; set; }
        public CarDto? CarDto { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime DateReturn { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalCost { get; set; }
    }
}
