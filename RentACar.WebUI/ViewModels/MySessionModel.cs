using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.WebUI.ViewModels
{
    public class MySessionModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string NameSurname { get; set; }

        public int CarCount { get; set; }

        public int BranchCount { get; set; }

    }
}