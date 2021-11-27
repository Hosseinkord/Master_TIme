using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMasterDateRepository:IDisposable
    {
        IEnumerable<MasterDate> GetAllMasterDates();
        MasterDate GetMasterDateById(int masterdateId);
        bool InsertMasterDate(MasterDate masterdate);
        bool UpdateMasterDate(MasterDate masterdate);
        bool DeleteMasterDate(MasterDate masterdate);
        bool DeleteMasterDate(int masterdateId);
        void save();

    }
}
