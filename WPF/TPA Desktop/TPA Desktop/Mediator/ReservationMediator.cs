using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class ReservationMediator
    {
        public List<Reservation> getAllReservation()
        {
            ReservationRepository repository = new ReservationRepository();
            return repository.getAllReservation();
        }

        public Reservation addReservation(Reservation reservation)
        {
            ReservationRepository repository = new ReservationRepository();
            return repository.addReservation(reservation);
        }

        public int getLastID()
        {
            ReservationRepository repository = new ReservationRepository();
            return repository.getLastID();
        }

        public Reservation getReservation(int reservationID)
        {
            ReservationRepository repository = new ReservationRepository();
            return repository.getReservation(reservationID);
        }

        public Reservation updateReservation(int reservationID, Reservation reservation)
        {
            ReservationRepository repository = new ReservationRepository();
            return repository.updateReservation(reservationID, reservation);
        }
    }
}
