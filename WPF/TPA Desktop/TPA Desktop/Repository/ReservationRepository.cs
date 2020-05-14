using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class ReservationRepository
    {
        public dynamic getAllReservation()
        {
            Connection con = Connection.getConnection();
            var result = (from r in con.db.Reservation
                          where r.status != "Finished"
                          select r).ToList();

            return result;
        }

        public Reservation addReservation(Reservation reservation)
        {
            Connection con = Connection.getConnection();
            con.db.Reservation.Add(reservation);
            con.db.SaveChanges();

            return reservation;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Reservation reservation = (from r in con.db.Reservation orderby r.reservationID descending select r).FirstOrDefault();
            if(reservation == null)
            {
                return 0;
            }
            return reservation.reservationID;
        }

        public Reservation getReservation(int reservationID)
        {
            Connection con = Connection.getConnection();
            return con.db.Reservation.Find(reservationID);
        }

        public Reservation updateReservation(int reservationID, Reservation reservation)
        {
            Connection con = Connection.getConnection();

            Reservation newReservation = con.db.Reservation.Find(reservationID);
            newReservation = reservation;
            con.db.SaveChanges();

            return newReservation;
        }
    }
}
