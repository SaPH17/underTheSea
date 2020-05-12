using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class Connection
    {
        public static Connection con;

        public UnderTheSeaEntities db = new UnderTheSeaEntities();

        public static Connection getConnection()
        {
            if(con == null)
            {
                con = new Connection();
            }
            return con;

        }
    }
}
