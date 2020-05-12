using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class FeedbackMediator
    {
        public Feedback addFeedback(Feedback feedback)
        {
            FeedbackRepository repository = new FeedbackRepository();
            return repository.addFeedback(feedback);
        }

        public int getLastID()
        {
            FeedbackRepository repository = new FeedbackRepository();
            return repository.getLastID();
        }

        public dynamic getAllFeedback(string receiver)
        {
            FeedbackRepository repository = new FeedbackRepository();
            return repository.getAllFeedback(receiver);
        }
    }
}
