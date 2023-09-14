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
    public class Car : DomainBase
    {
        //[Required]
        //public string VehicalId { get; set; }

        [Required]
        public string Maker { get; set; }

        [Required]
        public string Model { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal RentalPrice { get; set; }

        [Required]
        public bool AvailabilityStatus { get; set; }

    }
}
