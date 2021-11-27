using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository:ILoginRepository
    {
        private Pr_UniContext db;

        public LoginRepository(Pr_UniContext context)
        {
            this.db = context;
        }
        public IEnumerable<Login> GetAllLogins()
        {
            return db.Logins;
        }

        public Login GetLoginById(int LoginId)
        {
            return db.Logins.Find(LoginId);
        }
        public bool InsertLogin(Login login)
        {
            try
            {
                db.Logins.Add(login);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateLogin(Login login)
        {
            try
            {
                db.Entry(login).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLogin(int loginId)
        {
            try
            {
                var login = GetLoginById(loginId);
                DeleteLogin(login);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLogin(Login login)
        {
            try
            {
                db.Entry(login).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
