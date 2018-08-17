using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework.Manager;
using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Concrete
{
    public class EfBranchDal : IBranchDal
    {
        private DatabaseContext db = new DatabaseContext();

        public List<Branch> GetBranches()
        {
            return db.Branch.ToList();
        }

        public List<Branch> GetBranchesCityName(string city)
        {
            return db.Branch.Where(c => c.BranchCity == city).ToList();
        }

        public List<Branch> GetBranchesCountyName(string county)
        {
            return db.Branch.Where(c => c.BranchCounty == county).ToList();
        }

        public void SubeKaydet(Branch branch)
        {
            db.Branch.Add(branch);
            db.SaveChanges();
        }
    }
}
