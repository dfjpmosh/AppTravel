using AppTravel.Core.BusinessModels;
using AppTravel.Infrastructure.ExternalServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTravel.Infrastructure.ExternalServices
{
    public class ApiHotel2
    {
        public static async Task<List<HotelViewModel>> GetHotels()
        {
            var url = "https://academy-dotnet-hotel2.azurewebsites.net/api/location/l";
            var client = new HttpClient();
            var responseBody = await client.GetStringAsync(url);
            var lstHotel = JsonConvert.DeserializeObject<List<Hotel2>>(responseBody)
                .SelectMany(x => x.Cities.Select(c => ConvertToHotelViewModel(x.Id, x.stateName, c))).ToList();
            return lstHotel;
        }
        
        private static HotelViewModel ConvertToHotelViewModel(int id, string stateName, Hotel2Cities model)
        {
            return new HotelViewModel
            {
                IdHotel = 2,
                IdState = id,
                IdCity = model.Id,
                HotelName = "Hotel 2",
                State = stateName.Trim(),
                City = model.City.Trim()
            };
        }
    }
}
