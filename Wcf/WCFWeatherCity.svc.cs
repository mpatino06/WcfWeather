using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Wcf.DAL.Context;
using Wcf.DAL.Entities;
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

        public bool InsertWeatherCity(CityWeatherDTO city)
        {
            var result = 0;
            try
            {
                var entity = new CityWeather()
                {
                    IdCity = city.IdCity,
                    Description = city.Description,
                    Temperature = city.Temperature,
                    DateCreated = city.DateCreated
                };

                _context.CityWeather.Add(entity);
                _context.SaveChanges();
                result = entity.IdCityWeather;
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return (result > 0);
        }

        public bool UpdateWeatherCity(CityWeatherDTO city)
        {
            var entity = _context.CityWeather.FirstOrDefault(s => s.IdCityWeather == city.IdCityWeather);

            entity.IdCity = city.IdCity;
            entity.Description = city.Description;
            entity.Temperature = city.Temperature;
            entity.DateCreated = city.DateCreated;

            var result = _context.SaveChanges();

            return (result > 0);
        }

        public bool DeleteWeatherCity(int Id)
        {
            var entity = new CityWeather()
            {
                IdCityWeather = Id
            };
            _context.CityWeather.Attach(entity);
            _context.CityWeather.Remove(entity);
            _context.SaveChanges();

            return true;
        }
    }
}
