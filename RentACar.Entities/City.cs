using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class City
    {
        public string CityName { get; set; }
        //public virtual ICollection<County> County { get; set; }
        public List<string> County { get; set; }

    }
}
