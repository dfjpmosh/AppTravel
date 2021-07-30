using AppTravel.Core.BusinessModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTravel.Infrastructure.ExternalServices
{
    public class Hoteles
    {
        public static async Task<List<SearchHotelViewModel>> GetCityState()
        {
            var lstCityState = await ApiHotel1.GetHotels();
            lstCityState.AddRange(await ApiHotel2.GetHotels());

            var lstCities = lstCityState.Select(x => string.Concat(x.City, ", ", x.State)).Distinct().OrderBy(o => o.Trim()).ToList();

            return lstCities.Select(x => ConvertToSearchHotelViewModel(x)).ToList();
        }

        private static SearchHotelViewModel ConvertToSearchHotelViewModel(string model)
        {
            return new SearchHotelViewModel
            {
                CityState = model
            };
        }

        public static async Task<List<HotelViewModel>> GetHotels(string cityState)
        {            
            var lstHotels = await ApiHotel1.GetHotels();
            lstHotels.AddRange(await ApiHotel2.GetHotels());

            var city = cityState.Split(',')[0].Trim();
            var state = cityState.Split(',')[1].Trim();

            return lstHotels.Where(x => x.City == city && x.State == state).ToList();
        }

        public static async Task<HotelViewModel> GetHotel(int idHotel, int idState, int idCity)
        {
            var lstHotels = await ApiHotel1.GetHotels();
            lstHotels.AddRange(await ApiHotel2.GetHotels());

            return lstHotels.Where(x => x.IdHotel == idHotel && x.IdCity == idCity && x.IdState == idState).FirstOrDefault();
        }
    }
}
