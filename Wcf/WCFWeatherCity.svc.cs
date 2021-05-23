using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Wcf.DAL.Context;
using Wcf.DTOs;

namespace Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFWeatherCity" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFWeatherCity.svc or WCFWeatherCity.svc.cs at the Solution Explorer and start debugging.
    public class WCFWeatherCity : IWCFWeatherCity
    {
        //private readonly WCFDbContext _context;

        private readonly WCFDbContext _context = new WCFDbContext();



        public List<CityWeatherDTO> Get()
        {
            return _context.CityWeather.Select(
                a => new CityWeatherDTO
                {
                    IdCityWeather = a.IdCityWeather,
                    IdCity = a.IdCity,
                    City = a.IdCityNavigation.Name,
                    Temperature = a.Temperature,
                    Description = a.Description,
                    DateCreated = a.DateCreated
                }
                ).ToList();
        }

        public CityWeatherDTO GetWeatherCityById(int Id)
        {
            return _context.CityWeather.Select(
               a => new CityWeatherDTO
               {
                   IdCityWeather = a.IdCityWeather,
                   IdCity = a.IdCity,
                   City = a.IdCityNavigation.Name,
                   Temperature = a.Temperature,
                   Description = a.Description,
                   DateCreated = a.DateCreated
               }
               ).FirstOrDefault(a => a.IdCityWeather == Id);
        }

        public List<CityWeatherDTO> GetWeatherCityByIdCity(int Id)
        {
            return _context.CityWeather.Select(
               a => new CityWeatherDTO
               {
                   IdCityWeather = a.IdCityWeather,
                   IdCity = a.IdCity,
                   City = a.IdCityNavigation.Name,
                   Temperature = a.Temperature,
                   Description = a.Description,
                   DateCreated = a.DateCreated
               }
               ).Where(a => a.IdCity == Id).ToList();
        }

        public bool InsertWeatherCity(CityWeatherDTO User)
        {
            throw new NotImplementedException();
        }

        public void UpdateWeatherCity(CityWeatherDTO User)
        {
            throw new NotImplementedException();
        }

        public void DeleteWeatherCity(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
