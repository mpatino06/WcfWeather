using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceReferenceWeather;
using WebAppWeather.Models;
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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await cityWeatherRepository.Get();
            return View(result);
        }

        public IActionResult Create()
        {
            var model = new CityWeatherModel { City = "Bogota DC", IdCity = 1 };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityWeatherModel cityWeatherModel)
        {
            if (ModelState.IsValid)
            {
                cityWeatherModel.DateCreated = DateTime.Now;
                cityWeatherModel.IdCity = 1;

                var result = await cityWeatherRepository.InsertWeatherCity(cityWeatherModel);

                if (result)
                    return RedirectToAction("Index");
                else {
                    ViewBag.Error = "Error gurdando registro";
                    return View(cityWeatherModel);
                } 
            }
            return View(cityWeatherModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var result = await cityWeatherRepository.GetWeatherCityById((int)id);
            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CityWeatherModel cityWeatherModel)
        {
            if (ModelState.IsValid)
            {
                cityWeatherModel.DateCreated = DateTime.Now;
                cityWeatherModel.IdCity = 1;

                var result = await cityWeatherRepository.UpdateWeatherCity(cityWeatherModel);

                if (result)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Error = "Error Editando registro";
                    return View(cityWeatherModel);
                }
            }
            return View(cityWeatherModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var result = await cityWeatherRepository.GetWeatherCityById((int)id);
            if (result == null) return NotFound();

            return View(result);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(CityWeatherModel cityWeatherModel)
        {
            var result = await cityWeatherRepository.DeleteWeatherCity(cityWeatherModel.IdCityWeather);

            if (result)
                return RedirectToAction("Index");
            else
            {
                ViewBag.Error = "Error Eliminando registro";
               // var model = await cityWeatherRepository.GetWeatherCityById(id);
                return View(cityWeatherModel);
            }
        }

    }
}
