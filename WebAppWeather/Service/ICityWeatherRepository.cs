using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWeather.Models;

namespace WebAppWeather.Service
{
    public interface ICityWeatherRepository
    {
        Task<List<CityWeatherModel>> Get();
        Task<CityWeatherModel> GetWeatherCityById(int Id); 
        Task<List<CityWeatherModel>> GetWeatherCityByIdCity(int Id); 
        Task<bool> InsertWeatherCity(CityWeatherModel User); 
        Task<bool> UpdateWeatherCity(CityWeatherModel User);
        Task<bool> DeleteWeatherCity(int Id);
    }
}
