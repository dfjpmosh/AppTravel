using AppTravel.Core.BusinessModels;
using AppTravel.Infrastructure.ExternalServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTravel.Infrastructure.ExternalServices
{
    public class ApiHotel1
    {
        public static async Task<List<HotelViewModel>> GetHotels()
        {
            var url = "https://academy-dotnet-hotel1.azurewebsites.net/api/locations";
            var client = new HttpClient();
            var responseBody = await client.GetStringAsync(url);
            var lstHotel = JsonConvert.DeserializeObject<List<Hotel1>>(responseBody).Select( x => ConvertToHotelViewModel(x)).ToList();            
            return lstHotel;
        }

        private static HotelViewModel ConvertToHotelViewModel(Hotel1 model)
        {
            return new HotelViewModel
            {
                IdHotel = 1,
                IdState = model.Id,
                IdCity = model.Id,
                HotelName = "Hotel 1",
                State = model.Location.Split(',')[1].Trim(),
                City = model.Location.Split(',')[0].Trim()
            };
        }

        public static async Task<string> AddReservation(ReservationCommandModel reservationCommandModel)
        {
            var url = "https://academy-dotnet-hotel1.azurewebsites.net/api/room/1";
            var client = new HttpClient();
            var responseBody = await client.GetStringAsync(url);
            var lstHotel = JsonConvert.DeserializeObject<List<Hotel1>>(responseBody).Select(x => ConvertToHotelViewModel(x)).ToList();
            return null;
        }
    }    
}
