using AppTravel.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTravel.Core.ServicesInterfaces
{
    public interface IReservationService
    {
        void AddReservation(ReservationCommandModel reservationCommandModel);
    }
}
