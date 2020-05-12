using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class FeedbackFactory
    {
        public Feedback createNewFeedback(int customerID, string dept, string title, string description)
        {
            if(dept == "Hotel")
            {
                return createNewHotelFeedback(customerID, title, description);
            }
            else if(dept == "Restaurant")
            {
                return createNewRestaurantFeedback(customerID, title, description);
            }
            return null;
        }

        public Feedback createNewHotelFeedback(int customerID, string title, string description)
        {
            FeedbackMediator mediator = new FeedbackMediator();
            Feedback feedback = new Feedback();
            feedback.feedbackID = mediator.getLastID() + 1;
            feedback.customerID = customerID;
            feedback.title = title;
            feedback.description = description;
            feedback.receiver = "Hotel";

            return feedback;
        }

        public Feedback createNewRestaurantFeedback(int customerID, string title, string description)
        {
            FeedbackMediator mediator = new FeedbackMediator();
            Feedback feedback = new Feedback();
            feedback.feedbackID = mediator.getLastID() + 1;
            feedback.customerID = customerID;
            feedback.title = title;
            feedback.description = description;
            feedback.receiver = "Restaurant";

            return feedback;
        }
    }
}
