using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class Cal_EndRepository:ICal_EndRepository
    {
        private Pr_UniContext db;

        public Cal_EndRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Cal_End> GetAllCal_Ends()
        {
            return db.Cal_Ends;
        }

        public Cal_End GetCal_EndById(int cal_endId)
        {
            return db.Cal_Ends.Find(cal_endId);
        }
        public bool InsertCal_End(Cal_End cal_endId)
        {
            try
            {
                db.Cal_Ends.Add(cal_endId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCal_End(Cal_End cal_end)
        {
            try
            {
                db.Entry(cal_end).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCal_End(int cal_endId)
        {
            try
            {
                var cal_end = GetCal_EndById(cal_endId);
                DeleteCal_End(cal_end);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCal_End(Cal_End cal_end)
        {
            try
            {
                db.Entry(cal_end).State = EntityState.Deleted;
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
