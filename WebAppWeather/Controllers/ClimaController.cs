using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReferenceWeather;
using WebAppWeather.Service;

namespace WebAppWeather.Controllers
{
    public class ClimaController : Controller
    {
        private readonly ICityWeatherRepository cityWeatherRepository;

        public ClimaController(ICityWeatherRepository cityWeatherRepository)
        {
            this.cityWeatherRepository = cityWeatherRepository;
        }

        public async Task<IActionResult> Index()
        {


            var result = await cityWeatherRepository.Get();
            ViewBag.List = result;
 
            return View();
        }
    }
}
