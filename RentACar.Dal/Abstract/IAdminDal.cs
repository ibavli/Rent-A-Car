using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstract
{
    public interface IAdminDal
    {
        void CreateAdmin(Admin admin);

        Admin GetAdmin(string Username);

        void SaveWrongPassword(Admin admin);

        void BlockedAdmin(Admin admin);
    }
}
