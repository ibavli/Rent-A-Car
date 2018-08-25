using RentACar.Entities;
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

        List<Car> GetBranchesCars(string branchName);

        void SaveBranch(Branch branch, List<string> licensePlate);

        int GetBranchCount();

        List<Car> UpFilterResult();

        List<Car> DownFilterResult();

    }
}
