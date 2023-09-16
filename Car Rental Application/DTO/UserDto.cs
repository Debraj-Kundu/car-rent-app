using SharedLayer.Service;

namespace Car_Rental_Application.DTO
{
    public class UserDto : DtoBase
    {
        public string? Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Role { get; set; }
        public ICollection<RentedCarDto>? RentedCarDto { get; set; }

    }
}
