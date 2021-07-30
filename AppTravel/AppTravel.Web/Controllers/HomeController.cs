using AppTravel.Core.BusinessModels;
using AppTravel.Core.ServicesInterfaces;
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
        private readonly IReservationService _reservationService;

        public HomeController(ILogger<HomeController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
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
            if (!String.IsNullOrEmpty(obj.CityState))
            {
                obj.CityState =  obj.CityState;
                var lstHotels = await Hoteles.GetHotels(obj.CityState);

                ViewBag.CityState = obj.CityState;

                return View("HotelsAvailable", lstHotels);
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult HotelsAvailable(HotelViewModel hotels)
        {
            return View();
        }

        public ActionResult SelectHotel(int idHotel, int idState, int idCity)
        {
            return View();
        }

        public ActionResult Select(int idHotel, int idState, int idCity)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Select(ReservationCommandModel reservationCommandModel)
        {
            _reservationService.AddReservation(reservationCommandModel);
            return RedirectToAction("Index");
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
}
