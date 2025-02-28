﻿using SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BuisnessLayer.Domain
{
    public class CarDomain : DomainBase
    {
        //public string VehicalId { get; set; }

        public string Maker { get; set; }

        public string Model { get; set; }

        public decimal RentalPrice { get; set; }
        public string? CarImage { get; set; }
        public bool AvailabilityStatus { get; set; }
        public ICollection<RentedCarDomain>? RentedCarDomain { get; set; }
    }
}
