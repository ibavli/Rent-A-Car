using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class Vehicle
    {
        public Vehicle()
        {
            VehicleId = Guid.NewGuid();
        }

        [Key]
        public Guid VehicleId { get; set; }

        public string VehiclePhoto { get; set; }
        [Required]
        public string VehicleBrand { get; set; }
        [Required]
        public string VehicleModel { get; set; }
        [Required]
        public decimal VehiclePrice { get; set; }
        [Required]
        public int VehicleModelYear { get; set; }
        [Required]
        public string VehicleFuel { get; set; }
        [Required]
        public int VehicleAgeLimit { get; set; }
        [Required]
        public string LicensePlate { get; set; }

    }
}
