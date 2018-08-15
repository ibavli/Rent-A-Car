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
    public class EfAdminDal : IAdminDal
    {
        private DatabaseContext db = new DatabaseContext();

        public void CreateAdmin(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
        }

        public Admin GetAdmin(string Username)
        {
            return db.Admin.Where(a => a.UserName == Username).FirstOrDefault();
        }

        public void SaveWrongPassword(Admin admin)
        {
            Admin _admin = db.Admin.Where(a => a.UserName == admin.UserName).FirstOrDefault();
            _admin.PasswordEnteredIncorrectly = (_admin.PasswordEnteredIncorrectly + 1);
            db.SaveChanges();
        }
    }
}
