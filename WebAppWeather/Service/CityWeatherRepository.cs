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
            WCFWeatherCityClient client = new WCFWeatherCityClient();
            var result = await client.DeleteWeatherCityAsync(Id);

            return true;
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

        public async Task<CityWeatherModel> GetWeatherCityById(int Id)
        {
            CityWeatherModel modelo = new CityWeatherModel();
            WCFWeatherCityClient client = new WCFWeatherCityClient();
            var result = await client.GetWeatherCityByIdAsync(Id);

            if (result != null)
            {
                modelo = mapper.Map<CityWeatherModel>(result);
            }
            return modelo;
        }

        Task<List<CityWeatherModel>> ICityWeatherRepository.GetWeatherCityByIdCity(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertWeatherCity(CityWeatherModel city)
        {
            CityWeatherDTO modelo = new CityWeatherDTO {           
                IdCity = city.IdCity,
                Temperature = city.Temperature,
                Description = city.Description,
                DateCreated =  city.DateCreated
            };

            WCFWeatherCityClient client = new WCFWeatherCityClient();
            var result = await client.InsertWeatherCityAsync(modelo);
            return result;
        }

        public async Task<bool> UpdateWeatherCity(CityWeatherModel city)
        {
            CityWeatherDTO modelo = new CityWeatherDTO
            {
                IdCityWeather = city.IdCityWeather,
                IdCity = city.IdCity,
                Temperature = city.Temperature,
                Description = city.Description,
                DateCreated = city.DateCreated
            };

            WCFWeatherCityClient client = new WCFWeatherCityClient();
            var result = await client.UpdateWeatherCityAsync(modelo);
            return true;
        }
    }
}
