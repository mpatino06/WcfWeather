using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wcf.DAL.Context;
using Wcf.DTOs;
using Wcf.Interface;

namespace Wcf.Service
{
    public class CityWeatherService : ICityWeather
    {
        private readonly WCFDbContext _context;

        public CityWeatherService(WCFDbContext context)
        {
            this._context = context;
        }

        public void DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

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

        public CityWeatherDTO GetUserById(int Id)
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
               ).FirstOrDefault(a=> a.IdCityWeather == Id);
        }

        public bool InsertUser(CityWeatherDTO User)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(CityWeatherDTO User)
        {
            throw new NotImplementedException();
        }
    }
}