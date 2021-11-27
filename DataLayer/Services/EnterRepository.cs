using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public  class EnterRepository:IEnterRepository
    {
            private Pr_UniContext db;

            public EnterRepository(Pr_UniContext context)
            {
                this.db = context;
            }
            public IEnumerable<Enter> GetAllEnters()
            {
                return db.Enters;
            }

            public Enter GetEnterById(int enterId)
            {
                return db.Enters.Find(enterId);
            }
            public bool InsertEnter(Enter enter)
            {
                try
                {
                    db.Enters.Add(enter);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool UpdateEnter(Enter enter)
            {
                try
                {
                    db.Entry(enter).State = EntityState.Modified;
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool DeleteEnter(int enterId)
            {
                try
                {
                    var enter = GetEnterById(enterId);
                    DeleteEnter(enter);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool DeleteEnter(Enter enter)
            {
                try
                {
                    db.Entry(enter).State = EntityState.Deleted;
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
