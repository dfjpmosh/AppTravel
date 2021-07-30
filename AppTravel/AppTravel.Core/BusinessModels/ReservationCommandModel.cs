using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTravel.Core.BusinessModels
{
    public class ReservationCommandModel
    {
        public int IdReservation { get; set; }
        public int IdHotel { get; set; }
        public int IdState { get; set; }
        public int IdCity { get; set; }
        public string Name { get; set; }
        public string  LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

    }
}
