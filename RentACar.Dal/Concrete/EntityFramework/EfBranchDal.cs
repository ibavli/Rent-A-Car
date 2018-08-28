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
    public class EfBranchDal : IBranchDal
    {
        DatabaseContext db = DatabaseContext.CreateDBWithSingleton();
        public List<Car> DownFilterResult()
        {
            return db.Car.OrderBy(c => c.Vehicle.VehiclePrice).ToList();
        }

        public int GetBranchCount()
        {
            return db.Branch.ToList().Count();
        }

        public List<Branch> GetBranches()
        {
            return db.Branch.ToList();
        }

        public List<Car> GetBranchesCars(string branchName)
        {
            var branh = db.Branch.Where(b => b.BranchName == branchName).FirstOrDefault();
            return branh.BranchCars;
        }

        public List<Branch> GetBranchesCityName(string city)
        {
            return db.Branch.Where(b=>b.BranchCity == city).ToList();
        }

        public List<Branch> GetBranchesCountyName(string county)
        {
            return db.Branch.Where(b => b.BranchCounty == county).ToList();
        }

        public void SaveBranch(Branch branch, List<string> licensePlate)
        {
            List<Car> _cars = new List<Car>();
            foreach (var plate in licensePlate)
            {
                //_cars.Add(_carDal.GetCarByLicensePlate(car));
                _cars.Add(db.Car.Where(c => c.Vehicle.LicensePlate == plate).FirstOrDefault());
            }
            branch.BranchCars = _cars;
            db.Branch.Add(branch);
            db.SaveChanges();
        }

        public List<Car> UpFilterResult()
        {
            return db.Car.OrderByDescending(c => c.Vehicle.VehiclePrice).ToList();

        }
    }
}
