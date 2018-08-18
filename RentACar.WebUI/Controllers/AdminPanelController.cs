using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework;
using RentACar.Entities;
using RentACar.WebUI.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminPanelController : Controller
    {
        //Kötü yöntem. Fakat şimdilik böyle
        IFuelTypeDal _fuelTypeDal;
        IGearTypeDal _gearTypeDal;
        IVehicleTypeDal _vehicleTypeDal;
        ICarDal _carDal;
        IVehicleDal _vehicleDal;
        IBranchDal _branchDal;
        public AdminPanelController()
        {
            _fuelTypeDal = new EfFuelTypeDal();
            _gearTypeDal = new EfGearTypeDal();
            _vehicleTypeDal = new EfVehicleTypeDal();
            _carDal = new EfCarDal();
            _vehicleDal = new EfVehicleDal();
            _branchDal = new EfBranchDal();
        }

        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult FuelTypeAdd()
        {
            List<FuelType> _listFuelType = _fuelTypeDal.GetFuelTypes();
            if (_listFuelType != null) return View(_listFuelType);
            return View();
        }

        [HttpPost]
        public ActionResult FuelTypeAdd(string fuelType)
        {
            _fuelTypeDal.SaveFullType(fuelType);
            return RedirectToAction("FuelTypeAdd", "AdminPanel");
        }

        public ActionResult GearTypeAdd()
        {
            List<GearType> _listGearType = _gearTypeDal.GetGearTypes();
            if (_listGearType != null) return View(_listGearType);
            return View();
        }

        [HttpPost]
        public ActionResult GearTypeAdd(string gearType)
        {
            _gearTypeDal.SaveGearType(gearType);
            return RedirectToAction("GearTypeAdd", "AdminPanel");
        }

        public ActionResult VehicleTypeAdd()
        {
            List<VehicleType> _listVehicleType = _vehicleTypeDal.GetVehicleTypes();
            if (_listVehicleType != null) return View(_listVehicleType);
            return View();
        }

        [HttpPost]
        public ActionResult VehicleTypeAdd(string vehicleType)
        {
            _vehicleTypeDal.SaveVehicleType(vehicleType);
            return RedirectToAction("VehicleTypeAdd", "AdminPanel");
        }

        public ActionResult CreateCar()
        {
            VehicleAndCarViewModel model = new VehicleAndCarViewModel()
            {
                ListFuelType = _fuelTypeDal.GetFuelTypes(),
                ListGearType = _gearTypeDal.GetGearTypes(),
                ListVehicleType = _vehicleTypeDal.GetVehicleTypes()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCar(VehicleAndCarViewModel model)
        {
            _carDal.SaveCar(model.Car, model.Vehicle);
            return RedirectToAction("CreateCar", "AdminPanel");
        }

        public ActionResult CreateBranch()
        {
            return View(_carDal.GetCars());
        }
        [HttpPost]
        public ActionResult CreateBranch(string BranchName, string _City, string _county, params string[] checks)
        {
            //List<Car> _cars = new List<Car>();    
            List<string> _licensePlate = new List<string>();
            if (BranchName == "") BranchName = _City + " / " + _county;
            
                Branch branch = new Branch();
                branch.BranchName = BranchName;
                branch.BranchCounty = _county;
                branch.BranchCity = _City;
                foreach (var car in checks)
                {
                    //_cars.Add(_carDal.GetCarByLicensePlate(car));
                    _licensePlate.Add(car);
                }
                _branchDal.SaveBranch(branch, _licensePlate);
            
            return RedirectToAction("CreateBranch", "AdminPanel");
        }
        public JsonResult GetCities()
        {
            CityAndCountyViewModel model = new CityAndCountyViewModel();
            return Json(model.Cities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountyByCity(string cityName)
        {
            CityAndCountyViewModel model = new CityAndCountyViewModel();
            var result = model.Cities.Find(x => x.CityName == cityName);
            return Json(result.County, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetBranches()
        {
            return View(_branchDal.GetBranches());
        }
    }
}