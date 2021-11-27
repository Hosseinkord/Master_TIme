using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MasterLessonRepository:IMasterLessonRepository
    {
        private Pr_UniContext db;

        public MasterLessonRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<MasterLesson> GetAllMasterLessons()
        {
            return db.MasterLessons;
        }

        public MasterLesson GetMasterLessonById(int masterlessonId)
        {
            return db.MasterLessons.Find(masterlessonId);
        }
        public bool InsertMasterLesson(MasterLesson masterlesson)
        {
            try
            {
                db.MasterLessons.Add(masterlesson);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMasterLesson(MasterLesson masterlesson)
        {
            try
            {
                db.Entry(masterlesson).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMasterLesson(int masterlessonId)
        {
            try
            {
                var masterlesson = GetMasterLessonById(masterlessonId);
                DeleteMasterLesson(masterlesson);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMasterLesson(MasterLesson masterlesson)
        {
            try
            {
                db.Entry(masterlesson).State = EntityState.Deleted;
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
