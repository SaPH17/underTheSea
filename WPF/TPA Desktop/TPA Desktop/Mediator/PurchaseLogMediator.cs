using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class PurchaseLogMediator
    {
        public int getLastID()
        {
            PurchaseLogRepository repository = new PurchaseLogRepository();
            return repository.getLastID();
        }

        public PurchaseLog addPurchaseLog(PurchaseLog purchaseLog)
        {
            PurchaseLogRepository repository = new PurchaseLogRepository();
            return repository.addPurchaseLog(purchaseLog);
        }

        public List<PurchaseLog> getAllPurchaseLog()
        {
            PurchaseLogRepository repository = new PurchaseLogRepository();
            return repository.getAllPurchaseLog();
        }
    }
}
