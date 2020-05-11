using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class IdeaRepository
    {
        public List<Idea> getAllIdea()
        {
            Connection con = Connection.getConnection();
            return con.db.Idea.ToList();
        }

        public List<Idea> getAllIdea(string status)
        {
            Connection con = Connection.getConnection();
            return (from i in con.db.Idea where i.status == status select i).ToList();
        }

        public Idea getIdea(int ideaID)
        {
            Connection con = Connection.getConnection();
            return con.db.Idea.Find(ideaID);
        }

        public Idea updateIdea(int ideaID, Idea idea)
        {
            Connection con = Connection.getConnection();
            Idea newIdea = con.db.Idea.Find(ideaID);
            newIdea = idea;
            con.db.SaveChanges();
            return newIdea;
        }

        public Idea addIdea(Idea idea)
        {
            Connection con = Connection.getConnection();
            con.db.Idea.Add(idea);
            con.db.SaveChanges();

            return idea;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Idea idea = (from i in con.db.Idea orderby i.ideaID descending select i).FirstOrDefault();

            if(idea == null)
            {
                return 0;
            }
            else
            {
                return idea.ideaID;
            }

        }
    }
}
