using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class IdeaMediator
    {
        public List<Idea> getAllIdea()
        {
            IdeaRepository repository = new IdeaRepository();
            return repository.getAllIdea();
        }

        public List<Idea> getAllIdea(string status)
        {
            IdeaRepository repository = new IdeaRepository();
            return repository.getAllIdea(status);
        }

        public Idea getIdea(int ideaID)
        {
            IdeaRepository repository = new IdeaRepository();
            return repository.getIdea(ideaID);
        }

        public Idea updateIdea(int ideaID, Idea idea)
        {
            IdeaRepository repository = new IdeaRepository();
            return repository.updateIdea(ideaID, idea);
        }

        public Idea addIdea(Idea idea)
        {
            IdeaRepository repository = new IdeaRepository();
            return repository.addIdea(idea);
        }

        public int getLastID()
        {
            IdeaRepository repository = new IdeaRepository();
            return repository.getLastID();
        }
    }
}
