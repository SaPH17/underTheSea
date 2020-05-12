using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class ReservationFactory
    {
        public Reservation createNewReservation(int customerID, int roomID, DateTime? checkInDate, DateTime? checkOutDate)
        {
            ReservationMediator mediator = new ReservationMediator();
            Reservation reservation = new Reservation();
            reservation.reservationID = mediator.getLastID() + 1;
            reservation.customerID = customerID;
            reservation.roomID = roomID;
            reservation.checkInDate = checkInDate;
            reservation.checkOutDate = checkOutDate;
            reservation.status = "Active";

            return reservation;
        }
    }
}
