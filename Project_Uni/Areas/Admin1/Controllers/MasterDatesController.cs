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
    public class MasterDatesController : Controller
    {
        private ILoginRepository loginRepository;
        private IMasterDateRepository masterdateRepository;
        private IMasterRepository masterRepository;
        private IDateRepository dateRepository;



        Pr_UniContext db = new Pr_UniContext();
        public MasterDatesController()
        {
            loginRepository = new LoginRepository(db);
            masterdateRepository = new MasterDateRepository(db);
            masterRepository = new MasterRepository(db);
            dateRepository = new DateRepository(db);
        }

        // GET: Admin1/MasterDates
        public ActionResult Index()
        {
            ViewBag.Login = loginRepository.GetAllLogins();
            var masterDates = db.MasterDates.Include(m => m.Date).Include(c => c.Master);
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            return View(masterDates.ToList());
        }

        // GET: Admin1/MastersDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterDate masterdate = masterdateRepository.GetMasterDateById(id.Value);
            if (masterdate == null)
            {
                return HttpNotFound();
            }
            return View(masterdate);
        }

        // GET: Admin1/MastersDates/Create
        public ActionResult Create()
        {
            ViewBag.DateId = new SelectList(dateRepository.GetAllDates(), "DateId", "DateName");
            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName");
            return View();
        }

        // POST: Admin1/MastersDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MasterDateId,DateId,MasterCode,Status")] MasterDate masterdate)
        {
            if (ModelState.IsValid)
            {
                masterdateRepository.InsertMasterDate(masterdate);
                masterdateRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.DateId = new SelectList(dateRepository.GetAllDates(), "DateId", "DateName");
            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName");
            return View(masterdate);
        }

        // GET: Admin1/MasterDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterDate masterdate = masterdateRepository.GetMasterDateById(id.Value);
            if (masterdate == null)
            {
                return HttpNotFound();
            }
            ViewBag.DateId = new SelectList(dateRepository.GetAllDates(), "DateId", "DateName",masterdate.DateId);
            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName", masterdate.MasterCode);
            return View(masterdate);
        }

        // POST: Admin1/MasterDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MasterDateId,DateId,MasterCode,Status")] MasterDate masterdate)
        {
            if (ModelState.IsValid)
            {
                masterdateRepository.UpdateMasterDate(masterdate);
                masterdateRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.DateId = new SelectList(dateRepository.GetAllDates(), "DateId", "DateName", masterdate.DateId);
            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName", masterdate.MasterCode);
            return View(masterdate);
        }

        // GET: Admin1/MasterDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterDate masterdate = masterdateRepository.GetMasterDateById(id.Value);
            if (masterdate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            return View(masterdate);
        }

        // POST: Admin1/MasterDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            masterdateRepository.DeleteMasterDate(id);
            masterdateRepository.save();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                masterdateRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
