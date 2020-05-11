using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class IdeaFactory
    {
        public Idea createNewIdea(string name, string desc, string type, string category)
        {
            if(type == "Add")
            {
                return createNewAddIdea(name, desc, category);
            }
            else if(type == "Change")
            {
                return createNewChangeIdea(name, desc, category);
            }
            else if(type == "Destroy")
            {
                return createNewDestroyIdea(name, desc, category);
            }
            else
            {
                return null;
            }
        }

        private Idea createNewAddIdea(string name, string desc, string category)
        {
            IdeaMediator mediator = new IdeaMediator();

            Idea idea = new Idea();
            idea.ideaID = mediator.getLastID() + 1;
            idea.name = name;
            idea.description = desc;
            idea.response = "-";
            idea.status = "Pending";
            idea.type = "Add";
            idea.category = category;

            return idea;
        }
        private Idea createNewChangeIdea(string name, string desc, string category)
        {
            IdeaMediator mediator = new IdeaMediator();

            Idea idea = new Idea();
            idea.ideaID = mediator.getLastID() + 1;
            idea.name = name;
            idea.description = desc;
            idea.response = "-";
            idea.status = "Pending";
            idea.type = "Change";
            idea.category = category;

            return idea;
        }

        private Idea createNewDestroyIdea(string name, string desc, string category)
        {
            IdeaMediator mediator = new IdeaMediator();

            Idea idea = new Idea();
            idea.ideaID = mediator.getLastID() + 1;
            idea.name = name;
            idea.description = desc;
            idea.response = "-";
            idea.status = "Pending";
            idea.type = "Destroy";
            idea.category = category;

            return idea;
        }

    }
}
