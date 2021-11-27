using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMasterRepository:IDisposable
    {
        IEnumerable<Master> GetAllMasters();
        Master GetMasterById(int masterId);
        bool InsertMaster(Master master);
        bool UpdateMaster(Master master);
        bool DeleteMaster(Master master);
        bool DeleteMaster(int masterId);
        void save();
    }
}
