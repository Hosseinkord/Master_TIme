using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HelpRepository:IHelpRepository
    {
        private Pr_UniContext db;

        public HelpRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Help> GetAllHelps()
        {
            return db.Helps;
        }

        public Help GetHelpById(int helpId)
        {
            return db.Helps.Find(helpId);
        }
        public bool InsertHelp(Help help)
        {
            try
            {
                db.Helps.Add(help);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateHelp(Help help)
        {
            try
            {
                db.Entry(help).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHelp(int helpId)
        {
            try
            {
                var help = GetHelpById(helpId);
                DeleteHelp(help);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHelp(Help help)
        {
            try
            {
                db.Entry(help).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
