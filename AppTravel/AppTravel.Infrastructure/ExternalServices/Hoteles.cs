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
    }
}
