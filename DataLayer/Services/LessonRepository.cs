using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LessonRepository:ILessonRepository
    {
        private Pr_UniContext db;

        public LessonRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Lesson> GetAllLessons()
        {
            return db.Lessons;
        }

        public Lesson GetLessonById(int lessonId)
        {
            return db.Lessons.Find(lessonId);
        }
        public bool InsertLesson(Lesson lesson)
        {
            try
            {
                db.Lessons.Add(lesson);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateLesson(Lesson lesson)
        {
            try
            {
                db.Entry(lesson).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLesson(int lessonId)
        {
            try
            {
                var lesson = GetLessonById(lessonId);
                DeleteLesson(lesson);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLesson(Lesson lesson)
        {
            try
            {
                db.Entry(lesson).State = EntityState.Deleted;
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
