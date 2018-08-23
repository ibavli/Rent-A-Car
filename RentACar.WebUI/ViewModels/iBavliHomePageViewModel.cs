using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.WebUI.ViewModels
{
    public class iBavliHomePageViewModel
    {
        public List<Branch> Branches { get; set; }
        public List<Car> Cars{ get; set; }
    }
}