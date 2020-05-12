using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class FoodRepository
    {
        public Food getFood(int foodID)
        {
            Connection con = Connection.getConnection();

            return con.db.Food.Find(foodID);
        }
    }
}
