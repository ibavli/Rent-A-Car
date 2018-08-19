using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework.Manager;
using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Concrete.EntityFramework
{
    public class EfVehicleTypeDal : IVehicleTypeDal
    {
        private DatabaseContext db = new DatabaseContext();

        public void DeleteVehicleType(Guid id)
        {
            VehicleType vehicleType = db.VehicleType.Where(v => v.VehicleTypeId == id).FirstOrDefault();
            db.VehicleType.Remove(vehicleType);
            db.SaveChanges();
        }

        public List<VehicleType> GetVehicleTypes()
        {
            return db.VehicleType.ToList();
        }

        public void SaveVehicleType(string vehicleType)
        {
            VehicleType _vehicleType = new VehicleType()
            {
                TypeOfVehicle = vehicleType
            };
            db.VehicleType.Add(_vehicleType);
            db.SaveChanges();
        }
    }
}
