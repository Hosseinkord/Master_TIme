using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILabratorRepository:IDisposable
    {
        IEnumerable<Labratoryy> GetAllLabrators();
        Labratoryy GetLabratorById(int labratorId);
        bool InsertLabrator(Labratoryy labrator);
        bool UpdateLabrator(Labratoryy labrator);
        bool DeleteLabrator(Labratoryy labrator);
        bool DeleteLabrator(int labratorId);
        void save();
    }
}
