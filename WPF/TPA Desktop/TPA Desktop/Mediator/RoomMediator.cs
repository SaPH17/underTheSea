using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class RoomMediator
    {
        public Room getRoom(int roomID)
        {
            RoomRepository repository = new RoomRepository();
            return repository.getRoom(roomID);
        }

        public List<Room> getAllRoom()
        {
            RoomRepository repository = new RoomRepository();
            return repository.getAllRoom();
        }

        public Room updateRoom(int roomID, Room room)
        {
            RoomRepository repository = new RoomRepository();
            return repository.updateRoom(roomID, room);
        }
    }
}
