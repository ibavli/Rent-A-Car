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
    public class AdminController : Controller
    {
        IAdminDal _adminDal;
        public AdminController()
        {
            _adminDal = new EfAdminDal();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}