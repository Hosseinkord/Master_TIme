using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICal_EndRepository:IDisposable
    {
        IEnumerable<Cal_End> GetAllCal_Ends();
        Cal_End GetCal_EndById(int cal_endId);
        bool InsertCal_End(Cal_End cal_end);
        bool UpdateCal_End(Cal_End cal_end);
        bool DeleteCal_End(Cal_End cal_end);
        bool DeleteCal_End(int cal_endId);
        void save();
    }
}
