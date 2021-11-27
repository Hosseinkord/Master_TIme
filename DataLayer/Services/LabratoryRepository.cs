using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LabratoryRepository:ILabratorRepository
    {
        private Pr_UniContext db;

        public LabratoryRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Labratoryy> GetAllLabrators()
        {
            return db.Labrators;
        }

        public Labratoryy GetLabratorById(int labratorId)
        {
            return db.Labrators.Find(labratorId);
        }
        public bool InsertLabrator(Labratoryy labrator)
        {
            try
            {
                db.Labrators.Add(labrator);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateLabrator(Labratoryy labrator)
        {
            try
            {
                db.Entry(labrator).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLabrator(int labratorId)
        {
            try
            {
                var labrator = GetLabratorById(labratorId);
                DeleteLabrator(labrator);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLabrator(Labratoryy labrator)
        {
            try
            {
                db.Entry(labrator).State = EntityState.Deleted;
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
