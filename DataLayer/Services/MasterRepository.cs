using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MasterRepository:IMasterRepository
    {
            private Pr_UniContext db;

            public MasterRepository(Pr_UniContext context)
            {
                this.db = context;
            }
            public IEnumerable<Master> GetAllMasters()
            {
                return db.Masters;
            }

            public Master GetMasterById(int masterId)
            {
                return db.Masters.Find(masterId);
            }

            public bool InsertMaster(Master master)
            {
                try
                {
                    db.Masters.Add(master);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool UpdateMaster(Master master)
            {
                try
                {
                    db.Entry(master).State = EntityState.Modified;
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool DeleteMaster(int masterId)
            {
                try
                {
                    var master = GetMasterById(masterId);
                    DeleteMaster(master);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool DeleteMaster(Master master)
            {
                try
                {
                    db.Entry(master).State = EntityState.Deleted;
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
