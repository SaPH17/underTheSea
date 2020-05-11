using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class ConstructionProgressMediator
    {
        public dynamic getAllConstructionProgress()
        {
            ConstructionProgressRepository repository = new ConstructionProgressRepository();
            return repository.getAllConstructionProgress();
        }

        public int getLastID()
        {
            ConstructionProgressRepository repository = new ConstructionProgressRepository();
            return repository.getLastID();

        }

        public ConstructionProgress addConstructionProgress(ConstructionProgress cp)
        {
            ConstructionProgressRepository repository = new ConstructionProgressRepository();
            return repository.addConstructionProgress(cp);
        }
    }
}
