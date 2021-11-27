using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMasterLessonRepository:IDisposable
    {
        IEnumerable<MasterLesson> GetAllMasterLessons();
        MasterLesson GetMasterLessonById(int masterlessonId);
        bool InsertMasterLesson(MasterLesson masterlesson);
        bool UpdateMasterLesson(MasterLesson masterlesson);
        bool DeleteMasterLesson(MasterLesson masterlesson);
        bool DeleteMasterLesson(int masterlessonId);
        void save();

    }
}
