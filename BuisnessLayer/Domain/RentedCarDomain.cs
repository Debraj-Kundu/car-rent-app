using DataLayer.Entity;
using SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Domain
{
    public class RentedCarDomain : DomainBase
    {
        public int UserId { get; set; }
        public UserDomain? UserDomain { get; set; }
        public int CarId { get; set; }
        public CarDomain? CarDomain { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime DateReturn { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalCost { get; set; }
    }
}
