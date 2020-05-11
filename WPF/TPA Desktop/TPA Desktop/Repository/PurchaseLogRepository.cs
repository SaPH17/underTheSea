using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class PurchaseLogRepository
    {
        public int getLastID()
        {
            Connection con = Connection.getConnection();

            PurchaseLog purchase = (from p in con.db.PurchaseLog orderby p.purchaseLogID descending select p).FirstOrDefault();
            if (purchase == null)
            {
                return 0;
            }
            return purchase.purchaseLogID;
        }

        public PurchaseLog addPurchaseLog(PurchaseLog purchaseLog)
        {
            Connection con = Connection.getConnection();

            con.db.PurchaseLog.Add(purchaseLog);
            con.db.SaveChanges();

            return purchaseLog;
        }

        public List<PurchaseLog> getAllPurchaseLog()
        {
            Connection con = Connection.getConnection();

            return con.db.PurchaseLog.ToList();
        }
    }
}
