using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Project_Uni.Areas.Lab.Controllers
{
    public class LabratoryiesController : Controller
    {
        private IMasterRepository masterRepository;
        private ILoginRepository loginRepository;
        private ILabratorRepository labratoryRepository;

        public LabratoryiesController()
        {
            masterRepository = new MasterRepository(db);
            loginRepository = new LoginRepository(db);
            labratoryRepository = new LabratoryRepository(db);
        }
        private Pr_UniContext db = new Pr_UniContext();

        // GET: Lab/Labratoryies
        public ActionResult Index()
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Login = loginRepository.GetAllLogins();
            return View(db.Labrators.ToList());
        }

        // GET: Lab/Labratoryies/Details/5
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

        // GET: Lab/Labratoryies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lab/Labratoryies/Create
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

        // GET: Lab/Labratoryies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratoryy labratoryy = labratoryRepository.GetLabratorById(id.Value);
            if (labratoryy == null)
            {
                return HttpNotFound();
            }
            return View(labratoryy);
        }

        // POST: Lab/Labratoryies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabratorId,DateId,Labrator_description,Empty")] Labratoryy labratoryy)
        {
            if (ModelState.IsValid)
            {
                labratoryRepository.UpdateLabrator(labratoryy);
                labratoryRepository.save();
                return RedirectToAction("Index");
            }
            return View(labratoryy);
        }

        // GET: Lab/Labratoryies/Delete/5
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

        // POST: Lab/Labratoryies/Delete/5
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
