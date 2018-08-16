using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.WebUI.ViewModels
{
    public class VehicleAndCarViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Car Car { get; set; }
    }
}