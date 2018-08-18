﻿using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstract
{
    public interface IBranchDal
    {
        List<Branch> GetBranches();

        List<Branch> GetBranchesCityName(string city);

        List<Branch> GetBranchesCountyName(string county);

        void SubeKaydet(Branch branch);
    }
}