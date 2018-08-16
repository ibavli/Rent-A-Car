using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstract
{
    public interface IVehicleDal
    {
        List<Vehicle> GetVehicles();

        void SaveVehicle(Vehicle vehicle);
    }
}
