using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWeather.Models;
using ServiceReferenceWeather;
using AutoMapper;

namespace WebAppWeather.Service
{
    public class CityWeatherRepository : ICityWeatherRepository
    {
        private readonly IMapper mapper;

        public CityWeatherRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<bool> DeleteWeatherCity(int Id)
        {
            return true;
            //var result = await client.GetAsync();
        }

        public async Task<List<CityWeatherModel>> Get()
        {
            List<CityWeatherModel> modelo = new List<CityWeatherModel>();
            WCFWeatherCityClient client = new WCFWeatherCityClient();
            var result = await client.GetAsync();
        
            if (result != null)
            {
                modelo = mapper.Map<List<CityWeatherModel>>(result);
            }
            return modelo;
        }

        Task<CityWeatherModel> ICityWeatherRepository.GetWeatherCityById(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<CityWeatherModel>> ICityWeatherRepository.GetWeatherCityByIdCity(int Id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICityWeatherRepository.InsertWeatherCity(CityWeatherModel User)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICityWeatherRepository.UpdateWeatherCity(CityWeatherModel User)
        {
            throw new NotImplementedException();
        }
    }
}
