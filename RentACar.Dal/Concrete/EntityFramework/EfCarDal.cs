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
    public class EfCarDal : ICarDal
    {
        DatabaseContext db = DatabaseContext.CreateDBWithSingleton();
        public void DeleteCar(string licensePlate)
        {
            Car car = db.Car.Where(c => c.Vehicle.LicensePlate == licensePlate).FirstOrDefault();
            Vehicle vehicle = db.Vehicle.Where(c => c.LicensePlate == licensePlate).FirstOrDefault();
            if (car != null)
            {
                db.Car.Remove(car);
                db.Vehicle.Remove(vehicle);
                db.SaveChanges();
            }
            
        }

        public Car GetCarByLicensePlate(string licensePlate)
        {
            return db.Car.Where(c => c.Vehicle.LicensePlate == licensePlate).FirstOrDefault();
        }

        public int GetCarCount()
        {
            return db.Car.ToList().Count();
        }

        public List<Car> GetCars()
        {
            return db.Car.ToList();
        }

        public List<Car> GetThreeCars()
        {
            return db.Car.Take(3).ToList();
        }

        public void SaveCar(Car car, Vehicle vehicle)
        {
            car.Vehicle = vehicle;
            car.CarId = vehicle.VehicleId;
            db.Car.Add(car);
            db.SaveChanges();
        }
    }
}
