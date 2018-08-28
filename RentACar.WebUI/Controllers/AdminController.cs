using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework;
using RentACar.Entities;
using RentACar.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminController : Controller
    {

        //Kötü yöntem.Fakat ileride düzeltilecek.
        IAdminDal _adminDal;
        ICarDal _carDal;
        IBranchDal _branchDal;
        public AdminController()
        {
            _adminDal = new EfAdminDal();
            _carDal = new EfCarDal();
            _branchDal = new EfBranchDal();
        }
        public ActionResult Login()
        {
            Admin admin = _adminDal.GetAdmin("adminibo");
            if (admin == null)
            {
                //I produce salt
                var salt = Guid.NewGuid().ToString();

                //I create sample admin
                Admin sampleAdmin = new Admin()
                {
                    UserName = "adminibo",
                    Name = "ibrahim",
                    Surname = "bavlı",
                    Mail = "ibrahim.bavli35@gamil.com",
                    Salt = salt,
                    Password = "123456789",
                    IsAccountActive = true
                };
                //I'm encrypting the admin's password.
                sampleAdmin.Password = CryptoPass(sampleAdmin.UserName, sampleAdmin.Password, salt);
                _adminDal.CreateAdmin(sampleAdmin);
            }
            Session["login"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (Username.Length < 15 && Password.Length < 15)
            {
                Admin admin = _adminDal.GetAdmin(Username);
                if (admin != null)
                {
                    if (admin.Password == CryptoPass(Username, Password, admin.Salt))
                    {
                        if (admin.IsAccountActive == true)
                        {
                            MySessionModel mySessionModel = new MySessionModel();
                            mySessionModel.Id = admin.AdminId;
                            mySessionModel.UserName = admin.UserName;
                            mySessionModel.NameSurname = admin.Name + " " + admin.Surname;
                            mySessionModel.CarCount = _carDal.GetCarCount();
                            mySessionModel.BranchCount = _branchDal.GetBranchCount();
                            Session["login"] = mySessionModel;
                            return RedirectToAction("Homepage", "AdminPanel");
                        }
                        else
                        {
                            TempData["blocked"] = "Hesabınız aktif değildir. Lütfen epostanızdan kontrol ediniz.";
                            return View();
                        }
                    }
                    else
                    {
                        if (admin.IsAccountActive == true)
                        {
                            if (admin.PasswordEnteredIncorrectly == 4)
                            {
                                _adminDal.BlockedAdmin(admin);
                            }
                            else
                            {
                                _adminDal.SaveWrongPassword(admin);
                                TempData["wrongpassword"] = "Parolanızı yanlış girdiniz. 5 kere üst üste yanlış girerseniz hesabınız bloke olacaktır!";
                            }
                        }
                                  
                    }


                }
            }
            return View();
        }

        private string CryptoPass(string Username, string Password, string Salt)
        {
            string _firstAction = Username + Password;
            byte[] data = UTF8Encoding.UTF8.GetBytes(_firstAction);
            SHA512Managed sha = new SHA512Managed();
            byte[] result = sha.ComputeHash(data);
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < result.Length; i++)
            {
                output.Append(result[i].ToString("X2"));
            }
            string _secondAction = output.ToString();

            string _saltAction = _secondAction + Salt;
            byte[] data2 = UTF8Encoding.UTF8.GetBytes(_saltAction);
            SHA512Managed sha2 = new SHA512Managed();
            byte[] result2 = sha2.ComputeHash(data2);
            StringBuilder output2 = new StringBuilder("");
            for (int i = 0; i < result2.Length; i++)
            {
                output2.Append(result2[i].ToString("X2"));
            }
            string lastPassword = output2.ToString();
            return lastPassword;

        }

    }
}