using SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class User : DomainBase
    {
        //[Key]
        //[Required]
        //public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue("User")]
        public string Role { get; set; } = "User";
        public ICollection<RentedCar>? RentedCar { get; set; }
    }
}
