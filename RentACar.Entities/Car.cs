﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class Car
    {
        [Key]
        public Guid CarId { get; set; }

        public virtual Vehicle Vehicle{ get; set; }

        [Required]
        public string GearType { get; set; }
        [Required]
        public string VehicleType { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }
    }
}
