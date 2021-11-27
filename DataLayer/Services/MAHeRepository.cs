using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MAHeRepository:IMEHeRepository
    {
        private Pr_UniContext db;

        public MAHeRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<MAHe> GetAllMAHes()
        {
            return db.MAHes;
        }

        public MAHe GetMAHeById(int mAheId)
        {
            return db.MAHes.Find(mAheId);
        }
        public bool InsertMAHe(MAHe mAhe)
        {
            try
            {
                db.MAHes.Add(mAhe);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMAHe(MAHe mAhe)
        {
            try
            {
                db.Entry(mAhe).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMAHe(int mAheId)
        {
            try
            {
                var mAhe = GetMAHeById(mAheId);
                DeleteMAHe(mAhe);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMAHe(MAHe mAhe)
        {
            try
            {
                db.Entry(mAhe).State = EntityState.Deleted;
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
