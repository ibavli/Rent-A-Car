using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class FuelType
    {
        public FuelType()
        {
            FuelTypeId = Guid.NewGuid();
        }

        [Key]
        public Guid FuelTypeId { get; set; }

        public string Fuel { get; set; }
    }
}
