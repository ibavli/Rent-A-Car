using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework;
using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminPanelController : Controller
    {
        IFuelTypeDal _fuelTypeDal;
        public AdminPanelController()
        {
            _fuelTypeDal = new EfFuelTypeDal();
        }
        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult YakitTipiEkle()
        {
            List<FuelType> _listFuelType = _fuelTypeDal.GetFuelTypes();
            if (_listFuelType != null) return View(_listFuelType);
            return View();
        }
        [HttpPost]
        public ActionResult YakitTipiEkle(string fuelType)
        {
            _fuelTypeDal.SaveFullType(fuelType);
            return RedirectToAction("YakitTipiEkle", "AdminPanel");
        }
    }
}