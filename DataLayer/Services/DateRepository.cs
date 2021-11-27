using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DateRepository : IDateRepository
    {
        private Pr_UniContext db;

        public DateRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Date> GetAllDates()
        {
            return db.Dates;
        }

        public Date GetDateById(int dateId)
        {
            return db.Dates.Find(dateId);
        }
        public bool InsertDate(Date date)
        {
            try
            {
                db.Dates.Add(date);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateDate(Date date)
        {
            try
            {
                db.Entry(date).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteDate(int dateId)
        {
            try
            {
                var date = GetDateById(dateId);
                DeleteDate(date);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteDate(Date date)
        {
            try
            {
                db.Entry(date).State = EntityState.Deleted;
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
