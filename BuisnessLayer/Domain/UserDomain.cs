using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLayer.Domain;

namespace BuisnessLayer.Domain
{
    public class UserDomain : DomainBase
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
        public ICollection<RentedCarDomain>? RentedCarDomain { get; set; }

    }
}
