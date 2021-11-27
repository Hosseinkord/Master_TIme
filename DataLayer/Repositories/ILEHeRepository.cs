using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILEHeRepository:IDisposable
    {
        IEnumerable<LEHe> GetAllLEHes();
        LEHe GetLEHeById(int lEheId);
        bool InsertLEHe(LEHe lEhe);
        bool UpdateLEHe(LEHe lEhe);
        bool DeleteLEHe(LEHe lEhe);
        bool DeleteLEHe(int lEheId);
        void save();
    }
}
