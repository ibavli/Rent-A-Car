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

        public AdminPanelController()
        {
            _fuelTypeDal = new EfFuelTypeDal();
            _gearTypeDal = new EfGearTypeDal();
            _vehicleTypeDal = new EfVehicleTypeDal();
            _carDal = new EfCarDal();
            _vehicleDal = new EfVehicleDal();
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
        public ActionResult CreateCar(VehicleAndCarViewModel deneme)
        {
            return RedirectToAction("CreateCar", "AdminPanel");
        }

        public ActionResult CreateBranch()
        {
            CityAndCountyViewModel model = new CityAndCountyViewModel();
            

            return View(model);
        }
    }
}