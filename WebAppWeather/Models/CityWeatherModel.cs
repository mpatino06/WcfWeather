﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWeather.Models
{
    public class CityWeatherModel
    {
        public int IdCityWeather { get; set; }
        public int? IdCity { get; set; }
        public string City { get; set; }
        public decimal? Temperature { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
