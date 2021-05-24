using AutoMapper;
using ServiceReferenceWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWeather.Models;

namespace WebAppWeather.Utility
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CityWeatherDTO, CityWeatherModel>();
        }
    }
}
