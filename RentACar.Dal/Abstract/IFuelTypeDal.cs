﻿using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstract
{
    public interface IFuelTypeDal
    {
        List<FuelType> GetFuelTypes();

        void SaveFullType(string fullType);

        void DeleteFuelType(Guid id);
    }
}
