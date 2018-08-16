using System;
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

        public string GearType { get; set; }

        public string VehicleType { get; set; }

        public int SeatingCapacity { get; set; }
    }
}
