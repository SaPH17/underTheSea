using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class PurchaseLogFactory
    {
        public PurchaseLog createNewPurchaseLog(string title, string desc, DateTime? purchaseDate, int totalPrice)
        {
            PurchaseLogMediator mediator = new PurchaseLogMediator();
            PurchaseLog purchaseLog = new PurchaseLog();

            purchaseLog.purchaseLogID = mediator.getLastID() + 1;
            purchaseLog.title = title;
            purchaseLog.description = desc;
            purchaseLog.purchaseDate = purchaseDate;
            purchaseLog.totalPrice = totalPrice;

            return purchaseLog;
        }
    }
}
