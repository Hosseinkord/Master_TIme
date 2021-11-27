using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;

namespace Project_Uni.Controllers
{
    public class VorodController : Controller
    {
        private ILoginRepository loginRepository;
        private Pr_UniContext db = new Pr_UniContext();


        public VorodController()
        {
            loginRepository = new LoginRepository(db);
        }
        // GET: Logins
        public ActionResult Index()
        {
            return View(db.Logins.ToList());
        }

        // GET: Logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginId,UserName,PassWord,Role")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        // GET: Logins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginId,UserName,PassWord,Role")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(login.Role>3 || login.Role<1)
            {
                ModelState.AddModelError("Role", "نقش را درست وارد کنید.");
            }
            if (ModelState.IsValid)
            {
                foreach(var logiin in loginRepository.GetAllLogins())
                {
                    if(logiin.UserName==login.UserName && logiin.PassWord==login.PassWord && logiin.Role==1)
                    {
                        return Redirect("/Admin1/Dates/Index");
                    }
                    else if (logiin.UserName == login.UserName && logiin.PassWord == login.PassWord && logiin.Role ==2)
                    {
                        return Redirect("/AdminMasters/MasterDates/Index/"+logiin.UserName);
                    }
                    else if (logiin.UserName == login.UserName && logiin.PassWord == login.PassWord && logiin.Role == 3)
                    {
                        return Redirect("/Lab/Labratoryies/Index");
                    }
                    else
                    { 
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                    }
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}
