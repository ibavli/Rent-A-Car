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
    public class EfGearTypeDal : IGearTypeDal
    {
        //private DatabaseContext db = new DatabaseContext();
        DatabaseContext db = DatabaseContext.CreateDBWithSingleton();
        public void DeleteGearType(Guid id)
        {
            GearType gearType = db.GearType.Where(f => f.GearTypeId == id).FirstOrDefault();
            db.GearType.Remove(gearType);
            db.SaveChanges();
        }

        public List<GearType> GetGearTypes()
        {
            return db.GearType.ToList();
        }

        public void SaveGearType(string gearType)
        {
            GearType _gearType = new GearType()
            {
                Gear = gearType
            };
            db.GearType.Add(_gearType);
            db.SaveChanges();
        }
    }
}
