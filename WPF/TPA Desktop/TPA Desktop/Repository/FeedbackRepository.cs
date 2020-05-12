using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class FeedbackRepository
    {
        public Feedback addFeedback(Feedback feedback)
        {
            Connection con = Connection.getConnection();

            con.db.Feedback.Add(feedback);
            con.db.SaveChanges();

            return feedback;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Feedback feedback = (from f in con.db.Feedback orderby f.feedbackID descending select f).FirstOrDefault();

            if(feedback == null)
            {
                return 0;
            }
            return feedback.feedbackID;
        }

        public dynamic getAllFeedback(string receiver)
        {
            Connection con = Connection.getConnection();

            var result = (from f in con.db.Feedback
                          join c in con.db.Customer on f.customerID equals c.customerID
                          where f.receiver == receiver
                          select new
                          {
                              f.feedbackID,
                              c.name,
                              f.title,
                              f.description
                          });

            return result.ToList();
        }
    }
}
