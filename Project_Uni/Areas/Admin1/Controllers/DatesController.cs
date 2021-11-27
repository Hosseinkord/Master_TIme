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
    public class DatesController : Controller
    {
        private IMasterRepository masterRepository;
        private ILoginRepository loginRepository;
        private IMasterLessonRepository masterlessonRepository;
        private IDateRepository dateRepository;
        private IMasterDateRepository masterdateRepository;

        Pr_UniContext db = new Pr_UniContext();
        public DatesController()
        {
            masterRepository = new MasterRepository(db);
            loginRepository = new LoginRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            masterdateRepository = new MasterDateRepository(db);
            dateRepository = new DateRepository(db);
        }

        // GET: Admin1/Dates
        public ActionResult Index()
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Login = loginRepository.GetAllLogins();
                return View(dateRepository.GetAllDates());
        }

        // GET: Admin1/Dates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = dateRepository.GetDateById(id.Value);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // GET: Admin1/Dates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin1/Dates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateId,DateName")] Date date)
        {
            ViewBag.OK = 1;
            try
            {
                if (ModelState.IsValid)
                {
                    dateRepository.InsertDate(date);
                    dateRepository.save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return Redirect("http://localhost:61776/Admin1/Dates/Error");
            }
            return Redirect("http://localhost:61776/Admin1/Dates/Error");
       }

        // GET: Admin1/Dates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = dateRepository.GetDateById(id.Value);
            if (date == null)
            {
                return Redirect("http://localhost:61776/Admin1/Dates/Error");
            }
            return View(date);
        }

        // POST: Admin1/Dates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateId,DateName")] Date date)
        {
            if (ModelState.IsValid)
            {
                dateRepository.UpdateDate(date);
                dateRepository.save();
                return RedirectToAction("Index");
            }
            return Redirect("http://localhost:61776/Admin1/Dates/Error");
        }

        // GET: Admin1/Dates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = dateRepository.GetDateById(id.Value);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Admin1/Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foreach (var hp in masterdateRepository.GetAllMasterDates())
            {
                if (hp.DateId == id)
                {
                    masterdateRepository.DeleteMasterDate(hp);
                }
            }
        


            dateRepository.DeleteDate(id);
            dateRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dateRepository.Dispose();
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
