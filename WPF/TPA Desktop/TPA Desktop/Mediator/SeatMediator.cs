using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class SeatMediator
    {
        public dynamic getAllSeat()
        {
            SeatRepository repository = new SeatRepository();
            return repository.getAllSeat();
        }

        public Seat getSeat(int seatID)
        {
            SeatRepository repository = new SeatRepository();
            return repository.getSeat(seatID);
        }

        public Seat updateSeat(int seatID, Seat seat)
        {
            SeatRepository repository = new SeatRepository();
            return repository.updateSeat(seatID, seat);
        }
    }
}
