using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.WebUI.ViewModels
{
    public class CityAndCountyViewModel
    {
        List<City> _cities = new List<City>();
        public CityAndCountyViewModel()
        {
            //List<County> izmirCounty = new List<County>();
            List<string> izmirCounty = new List<string>();
            izmirCounty.Add("Çiğli");
            izmirCounty.Add("Karşıyaka");
            izmirCounty.Add("Bornova");
            izmirCounty.Add("Alsancak");

            City izmir = new City()
            {
                CityName = "İzmir",
                County = izmirCounty
            };

            List<string> istanbulCounty = new List<string>();
            istanbulCounty.Add("Beşiktaş");
            istanbulCounty.Add("Sarıyer");
            istanbulCounty.Add("Avcılar");
            istanbulCounty.Add("Ataşehir");

            City istanbul = new City()
            {
                CityName = "İstanbul",
                County = istanbulCounty
            };
            
            _cities.Add(izmir);
            _cities.Add(istanbul);
        }

        public List<City> Cities
        {
            get
            {
                return _cities;
            }
        }
        
    }
}