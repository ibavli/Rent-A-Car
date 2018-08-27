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
    public class EfFuelTypeDal : IFuelTypeDal
    {
        //private DatabaseContext db = new DatabaseContext();
        DatabaseContext db = DatabaseContext.CreateDBWithSingleton();
        public void DeleteFuelType(Guid id)
        {
            FuelType fuelType = db.FuelType.Where(f => f.FuelTypeId == id).FirstOrDefault();
            db.FuelType.Remove(fuelType);
            db.SaveChanges();
        }

        public List<FuelType> GetFuelTypes()
        {
            return db.FuelType.ToList();
        }

        public void SaveFullType(string fullType)
        {
            FuelType _fuelType = new FuelType()
            {
                Fuel = fullType
            };
            db.FuelType.Add(_fuelType);
            db.SaveChanges();
        }
    }
}
