using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPA_Desktop.Model;

namespace TPA_Desktop
{
    public class Session
    { 
        public static Session session;

        public Employee employee;
        public Window window;

        public static Session getSession()
        {
            if(session == null)
            {
                session = new Session();
                return session;
            }
            else
            {
                return session;
            }
        }
    }
}
