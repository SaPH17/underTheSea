using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class RoomRepository
    {
        public Room getRoom(int roomID)
        {
            Connection con = Connection.getConnection();
            return con.db.Room.Find(roomID);
        }

        public List<Room> getAllRoom()
        {
            Connection con = Connection.getConnection();
            return con.db.Room.ToList();
        }

        public Room updateRoom(int roomID, Room room)
        {
            Connection con = Connection.getConnection();

            Room newRoom = con.db.Room.Find(roomID);
            newRoom = room;
            con.db.SaveChanges();
            return newRoom;
        }
    }
}
