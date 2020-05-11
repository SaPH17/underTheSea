using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class CleaningLogRepository
    {
        public int getLastID()
        {
            Connection con = Connection.getConnection();
            CleaningLog cleaningLog = (from c in con.db.CleaningLog orderby c.cleaningLogID descending select c).FirstOrDefault();
            if(cleaningLog == null)
            {
                return 0;
            }
            else
            {
                return cleaningLog.cleaningLogID;
            }

        }

        public CleaningLog addCleaningLog(CleaningLog cleaningLog)
        {
            Connection con = Connection.getConnection();
            con.db.CleaningLog.Add(cleaningLog);
            con.db.SaveChanges();
            return cleaningLog;
        }
    }
}
