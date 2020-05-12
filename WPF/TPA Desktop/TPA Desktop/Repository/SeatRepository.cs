using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class SeatRepository
    {
        public dynamic getAllSeat()
        {
            Connection con = Connection.getConnection();

            var result = (from s in con.db.Seat
                          select new
                          {
                              s.seatID,
                              s.chairQuantity,
                              s.status
                          });

            return result.ToList();
        }

        public Seat getSeat(int seatID)
        {
            Connection con = Connection.getConnection();

            return con.db.Seat.Find(seatID);
        }

        public Seat updateSeat(int seatID, Seat seat)
        {
            Connection con = Connection.getConnection();

            Seat newSeat = con.db.Seat.Find(seatID);
            newSeat = seat;
            con.db.SaveChanges();

            return newSeat;
        }
    }
}
