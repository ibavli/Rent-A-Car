using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class VehicleType
    {
        public VehicleType()
        {
            VehicleTypeId = Guid.NewGuid();
        }

        [Key]
        public Guid VehicleTypeId { get; set; }

        public string TypeOfVehicle { get; set; }
    }
}
