using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstract
{
    public interface ICarDal
    {
        List<Car> GetCars();

        Car GetCarByLicensePlate(string licensePlate);

        void SaveCar(Car car, Vehicle vehicle);

        void DeleteCar(string licensePlate);

        int GetCarCount();
    }
}
