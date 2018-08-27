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
    public class EfVehicleDal : IVehicleDal
    {
        //private DatabaseContext db = new DatabaseContext();
        DatabaseContext db = DatabaseContext.CreateDBWithSingleton();
        public List<Vehicle> GetVehicles()
        {
            return db.Vehicle.ToList();
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            db.Vehicle.Add(vehicle);
            db.SaveChanges();
        }
    }
}
