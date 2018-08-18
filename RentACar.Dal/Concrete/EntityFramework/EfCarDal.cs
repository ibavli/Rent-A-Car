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
        private DatabaseContext db = new DatabaseContext();

        public Car GetCarByLicensePlate(string licensePlate)
        {
            return db.Car.Where(c => c.Vehicle.LicensePlate == licensePlate).FirstOrDefault();
        }

        public List<Car> GetCars()
        {
            return db.Car.ToList();
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
