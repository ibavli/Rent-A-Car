using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities
{
    public class Branch
    {
        public Branch()
        {
            this.BranchCars = new List<Car>();
            BranchId = Guid.NewGuid();
        }

        [Key]
        public Guid BranchId { get; set; }

        public string BranchCity { get; set; }

        public string BranchCounty { get; set; }

        public string BranchName { get; set; }

        public virtual List<Car> BranchCars { get; set; }
    }
}
