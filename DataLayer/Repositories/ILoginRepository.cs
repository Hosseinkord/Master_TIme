using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILoginRepository:IDisposable
    {
        IEnumerable<Login> GetAllLogins();
        Login GetLoginById(int loginId);
        bool InsertLogin(Login login);
        bool UpdateLogin(Login login);
        bool DeleteLogin(Login login);
        bool DeleteLogin(int loginId);
        void save();
    }
}
