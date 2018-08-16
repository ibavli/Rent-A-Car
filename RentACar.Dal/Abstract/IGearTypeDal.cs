using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstract
{
    public interface IGearTypeDal
    {
        List<GearType> GetGearTypes();

        void SaveGearType(string gearType);
    }
}
