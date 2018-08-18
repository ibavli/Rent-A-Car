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

        public string VehicleBrand { get; set; }

        public string VehicleModel { get; set; }

        public decimal VehiclePrice { get; set; }

        public int VehicleModelYear { get; set; }

        public string VehicleFuel { get; set; }

        public int VehicleAgeLimit { get; set; }

        public string LicensePlate { get; set; }

    }
}
