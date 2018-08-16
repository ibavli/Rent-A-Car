using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class GearType
    {
        public GearType()
        {
            GearTypeId = Guid.NewGuid();
        }

        [Key]
        public Guid GearTypeId { get; set; }

        public string Gear { get; set; }
    }
}
