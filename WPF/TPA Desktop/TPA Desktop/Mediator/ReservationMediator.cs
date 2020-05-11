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
    }
}
