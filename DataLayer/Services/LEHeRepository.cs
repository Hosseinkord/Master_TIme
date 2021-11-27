using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LEHeRepository:ILEHeRepository
    {
        private Pr_UniContext db;

        public LEHeRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<LEHe> GetAllLEHes()
        {
            return db.LEHes;
        }

        public LEHe GetLEHeById(int lEheId)
        {
            return db.LEHes.Find(lEheId);
        }
        public bool InsertLEHe(LEHe lEhe)
        {
            try
            {
                db.LEHes.Add(lEhe);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateLEHe(LEHe lEhe)
        {
            try
            {
                db.Entry(lEhe).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLEHe(int lEheId)
        {
            try
            {
                var lEhe = GetLEHeById(lEheId);
                DeleteLEHe(lEhe);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLEHe(LEHe lEhe)
        {
            try
            {
                db.Entry(lEhe).State = EntityState.Deleted;
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
