using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MasterDateRepository:IMasterDateRepository
    {
        private Pr_UniContext db;

        public MasterDateRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<MasterDate> GetAllMasterDates()
        {
            return db.MasterDates;
        }

        public MasterDate GetMasterDateById(int masterdateId)
        {
            return db.MasterDates.Find(masterdateId);
        }
        public bool InsertMasterDate(MasterDate masterdate)
        {
            try
            {
                db.MasterDates.Add(masterdate);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMasterDate(MasterDate masterdate)
        {
            try
            {
                db.Entry(masterdate).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMasterDate(int masterdateId)
        {
            try
            {
                var masterdate = GetMasterDateById(masterdateId);
                DeleteMasterDate(masterdate);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMasterDate(MasterDate masterdate)
        {
            try
            {
                db.Entry(masterdate).State = EntityState.Deleted;
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
