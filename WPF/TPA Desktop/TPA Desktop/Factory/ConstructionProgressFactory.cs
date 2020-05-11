using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class ConstructionProgressFactory
    {
        public ConstructionProgress createNewConstructionProgress(int attractionID, string title, string desc, DateTime? progressDate)
        {
            ConstructionProgressMediator mediator = new ConstructionProgressMediator();
            ConstructionProgress cp = new ConstructionProgress();

            cp.progressID = mediator.getLastID() + 1;
            cp.attractionID = attractionID;
            cp.title = title;
            cp.description = desc;
            cp.progressDate = progressDate;

            return cp;
        }
    }
}
