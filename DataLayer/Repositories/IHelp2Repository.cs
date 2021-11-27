using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IHelp2Repository:IDisposable
    {
        IEnumerable<Help2> GetAllHelp2s();
        Help2 GetHelp2ById(int help2Id);
        bool InsertHelp2(Help2 help2);
        bool UpdateHelp2(Help2 help2);
        bool DeleteHelp2(Help2 help2);
        bool DeleteHelp2(int help2Id);
        void save();
    }
}
