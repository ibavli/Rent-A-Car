﻿using RentACar.Dal.Abstract;
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

            //Example data
            Admin admin = new Admin()
            {
                Name = "ibrahim",
                Surname = "bavlı",
                Mail = "ibrahim@gmail.com",
                Mobile = "5065555",
                Password = "123",
                UserName = "adminibo"
            };
            _adminDal.CreateAdmin(admin);
            return View();
        }
    }
}