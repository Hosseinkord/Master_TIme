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
    public class LabratoryiesController : Controller
    {
        private IMasterRepository masterRepository;
        private IDateRepository dateRepository;
        private ILoginRepository loginRepository;
        private ILabratorRepository labratoryRepository;



        private Pr_UniContext db = new Pr_UniContext();


        public LabratoryiesController()
        {
            masterRepository = new MasterRepository(db);
            loginRepository = new LoginRepository(db);
            dateRepository = new DateRepository(db);
            labratoryRepository = new LabratoryRepository(db);
        }
        // GET: Admin1/Labratoryies
        public ActionResult Index()
        {
            ViewBag.Login = loginRepository.GetAllLogins();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            return View(labratoryRepository.GetAllLabrators());
        }

        // GET: Admin1/Labratoryies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratoryy labratoryy = db.Labrators.Find(id);
            if (labratoryy == null)
            {
                return HttpNotFound();
            }
            return View(labratoryy);
        }

        // GET: Admin1/Labratoryies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin1/Labratoryies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabratorId,DateId,Labrator_description,Empty")] Labratoryy labratoryy)
        {
            if (ModelState.IsValid)
            {
                db.Labrators.Add(labratoryy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labratoryy);
        }

        // GET: Admin1/Labratoryies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratoryy labratoryy = db.Labrators.Find(id);
            if (labratoryy == null)
            {
                return HttpNotFound();
            }
            return View(labratoryy);
        }

        // POST: Admin1/Labratoryies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabratorId,DateId,Labrator_description,Empty")] Labratoryy labratoryy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labratoryy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labratoryy);
        }

        // GET: Admin1/Labratoryies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratoryy labratoryy = db.Labrators.Find(id);
            if (labratoryy == null)
            {
                return HttpNotFound();
            }
            return View(labratoryy);
        }

        // POST: Admin1/Labratoryies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Labratoryy labratoryy = db.Labrators.Find(id);
            db.Labrators.Remove(labratoryy);
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
    }
}
