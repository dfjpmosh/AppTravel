using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTravel.Core.BusinessModels
{
    public class HotelViewModel
    {
        public int IdHotel { get; set; }
        public int IdState { get; set; }
        public int IdCity { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
