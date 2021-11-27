using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDateRepository : IDisposable
    {
        IEnumerable<Date> GetAllDates();
        Date GetDateById(int dateId);
        bool InsertDate(Date date);
        bool UpdateDate(Date date);
        bool DeleteDate(Date date);
        bool DeleteDate(int dateId);
        void save();
    }
}
