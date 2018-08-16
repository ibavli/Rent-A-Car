using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework;
using RentACar.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminPanelController : Controller
    {
        //Kötü yöntem. Fakat şimdilik böyle
        IFuelTypeDal _fuelTypeDal;
        IGearTypeDal _gearTypeDal;
        public AdminPanelController()
        {
            _fuelTypeDal = new EfFuelTypeDal();
            _gearTypeDal = new EfGearTypeDal();
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
    }
}