using AppTravel.Core.BusinessModels;
using AppTravel.Infrastructure.ExternalServices;
using AppTravel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppTravel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var lstCities = await Hoteles.GetCityState();

            List<SelectListItem> cities = lstCities.ConvertAll(h =>
            {
                return new SelectListItem()
                {
                    Text = h.CityState.ToString().Trim(),
                    Value = h.CityState.ToString().Trim(),
                    Selected = false
                };
            });

            ViewBag.cities = cities;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchHotelViewModel obj)
        {
            var lstCities = await Hoteles.GetCityState();

            List<SelectListItem> cities = lstCities.ConvertAll(h =>
            {
                return new SelectListItem()
                {
                    Text = h.CityState.ToString().Trim(),
                    Value = h.CityState.ToString().Trim(),
                    Selected = false
                };
            });

            ViewBag.cities = cities;
            
            string d = obj.CityState;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
