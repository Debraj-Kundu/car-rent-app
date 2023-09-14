using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class RentedCar : DomainBase
    {
        //[Key]
        //[Required]
        //public string RentalId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime DateReturn { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalCost { get; set; }

    }
}
