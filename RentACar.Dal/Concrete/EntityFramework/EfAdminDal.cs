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
    }
}
