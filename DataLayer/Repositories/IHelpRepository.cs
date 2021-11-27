using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public  interface IHelpRepository:IDisposable
    {
        IEnumerable<Help> GetAllHelps();
        Help GetHelpById(int helpId);
        bool InsertHelp(Help help);
        bool UpdateHelp(Help help);
        bool DeleteHelp(Help help);
        bool DeleteHelp(int helpId);
        void save();
    }
}
