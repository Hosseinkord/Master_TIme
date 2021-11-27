using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMEHeRepository:IDisposable
    {
        IEnumerable<MAHe> GetAllMAHes();
        MAHe GetMAHeById(int mAheId);
        bool InsertMAHe(MAHe mAhe);
        bool UpdateMAHe(MAHe mAhe);
        bool DeleteMAHe(MAHe mAhe);
        bool DeleteMAHe(int mAheId);
        void save();
    }
}
