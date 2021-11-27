using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IEnterRepository:IDisposable
    {
        IEnumerable<Enter> GetAllEnters();
        Enter GetEnterById(int enterId);
        bool InsertEnter(Enter enter);
        bool UpdateEnter(Enter enter);
        bool DeleteEnter(Enter enter);
        bool DeleteEnter(int enterId);
        void save();
    }
}
