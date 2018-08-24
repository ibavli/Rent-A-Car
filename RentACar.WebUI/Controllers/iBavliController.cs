using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework;
using RentACar.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class iBavliController : Controller
    {
        IBranchDal _branchDal;
        ICarDal _carDal;

        public iBavliController()
        {
            _branchDal = new EfBranchDal();
            _carDal = new EfCarDal();
        }
        public ActionResult AnaSayfa()
        {
            iBavliHomePageViewModel model = new iBavliHomePageViewModel()
            {
                Branches = _branchDal.GetBranches(),
                Cars = _carDal.GetThreeCars()
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult AnaSayfa(string rentedDate, string deliveryDate, string branchName)
        {
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime _rentedDate = DateTime.ParseExact(rentedDate, "MM/dd/yyyy", culture);

            IFormatProvider culture2 = new CultureInfo("en-US", true);
            DateTime _deliveryDate = DateTime.ParseExact(deliveryDate, "MM/dd/yyyy", culture2);

            TempData["branchName"] = branchName;

            return RedirectToAction("Sonuclar", "iBavli");
        }


        public ActionResult Sonuclar()
        {
            string branchName = (string)TempData["branchName"];
            if (branchName == null) return RedirectToAction("AnaSayfa","iBavli");
            else
            {
                var model = _branchDal.GetBranchesCars(branchName);
                return View(model);
            }
            
        }
    }
}