using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Help2Repository : IHelp2Repository
    {
        private Pr_UniContext db;

        public Help2Repository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Help2> GetAllHelp2s()
        {
            return db.Help2s;
        }

        public Help2 GetHelp2ById(int help2Id)
        {
            return db.Help2s.Find(help2Id);
        }
        public bool InsertHelp2(Help2 help2)
        {
            try
            {
                db.Help2s.Add(help2);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateHelp2(Help2 help2)
        {
            try
            {
                db.Entry(help2).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHelp2(int help2Id)
        {
            try
            {
                var help2 = GetHelp2ById(help2Id);
                DeleteHelp2(help2);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHelp2(Help2 help2)
        {
            try
            {
                db.Entry(help2).State = EntityState.Deleted;
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