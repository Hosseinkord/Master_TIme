using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILessonRepository:IDisposable
    {
        IEnumerable<Lesson> GetAllLessons();
        Lesson GetLessonById(int lessonId);
        bool InsertLesson(Lesson lesson);
        bool UpdateLesson(Lesson lesson);
        bool DeleteLesson(Lesson lesson);
        bool DeleteLesson(int lessonId);

        void save();

    }
}
