using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Project_Uni.Areas.Admin1.Controllers
{
    public class LoginsController : Controller
    {
        private ILoginRepository loginRepository;
        private IMasterLessonRepository masterlessonRepository;
        private IMasterRepository masterRepository;
        private IMasterDateRepository masterdateRepository;
        Pr_UniContext db = new Pr_UniContext();
        public LoginsController()
        {
            loginRepository = new LoginRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            masterdateRepository = new MasterDateRepository(db);
            masterRepository = new MasterRepository(db);
        }

        // GET: Admin1/Masterس
        public ActionResult Index()
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            return View(loginRepository.GetAllLogins());
        }

        // GET: Admin1/Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = loginRepository.GetLoginById(id.Value);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Admin1/masters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin1/masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginId,PassWord,UserName,Role")] Login login)
        {
            if (ModelState.IsValid)
            {
                loginRepository.InsertLogin(login);
                loginRepository.save();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Admin1/masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = loginRepository.GetLoginById(id.Value);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Admin1/masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginId,PassWord,UserName,Role")] Login login)
        {
            if (ModelState.IsValid)
            {
                loginRepository.UpdateLogin(login);
                loginRepository.save();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Admin1/masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = loginRepository.GetLoginById(id.Value);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Admin1/masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            loginRepository.DeleteLogin(id);
            loginRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                loginRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}
