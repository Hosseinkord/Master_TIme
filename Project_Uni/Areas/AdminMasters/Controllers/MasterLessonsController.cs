using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Project_Uni.Areas.AdminMasters.Controllers
{
    public class MasterLessonsController : Controller
    {
        private IMasterDateRepository masterdateRepository;
        private IMasterLessonRepository masterlessonRepository;
        private IMasterRepository masterRepository;
        private ILessonRepository lessonRepository;

        private Pr_UniContext db = new Pr_UniContext();

        public MasterLessonsController()
        {
            masterdateRepository = new MasterDateRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            masterRepository = new MasterRepository(db);
            lessonRepository = new LessonRepository(db);
        }

        // GET: Admin1/MasterLessons
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            var masterLessons = db.MasterLessons.Include(m => m.Lesson).Include(m => m.Master);
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.MasterLesson = masterlessonRepository.GetAllMasterLessons();
            return View(masterlessonRepository.GetAllMasterLessons());
        }

        // GET: Admin1/MasterLessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterLesson masterlesson = masterlessonRepository.GetMasterLessonById(id.Value);
            if (masterlesson == null)
            {
                return HttpNotFound();
            }
            return View(masterlesson); ;
        }

        // GET: Admin1/MasterLessons/Create
        public ActionResult Create(int id,int l)
        {
            ViewBag.LessonCode = new SelectList(db.Lessons, "LessonCode", "LessonName");
            ViewBag.MasterCode = new SelectList(db.Masters, "MasterCode", "MasterName");
            return View();
        }

        // POST: Admin1/MasterLessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MasterLessonId,MasterCode,LessonCode,Prefer")] MasterLesson masterlesson)
        {
            if (ModelState.IsValid)
            {
                masterlessonRepository.InsertMasterLesson(masterlesson);
                masterlessonRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.LessonCode = new SelectList(lessonRepository.GetAllLessons(), "LessonCode", "LessonName", masterlesson.LessonCode);

            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName", masterlesson.MasterCode);
            return View(masterlesson);
        }

        // GET: Admin1/MasterLessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterLesson masterlesson = masterlessonRepository.GetMasterLessonById(id.Value);
            if (masterlesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.LessonCode = new SelectList(lessonRepository.GetAllLessons(), "LessonCode", "LessonName", masterlesson.LessonCode);
            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName", masterlesson.MasterCode);
            return View(masterlesson);
        }

        // POST: Admin1/MasterLessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MasterLessonId,MasterCode,LessonCode,Prefer")] MasterLesson masterlesson)
        {
            if (ModelState.IsValid)
            {
                masterlessonRepository.UpdateMasterLesson(masterlesson);
                masterlessonRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.LessonCode = new SelectList(lessonRepository.GetAllLessons(), "LessonCode", "LessonName", masterlesson.LessonCode);
            ViewBag.MasterCode = new SelectList(masterRepository.GetAllMasters(), "MasterCode", "MasterName", masterlesson.MasterCode);
            return View(masterlesson);
        }

        // GET: Admin1/MasterLessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterLesson masterlesson = masterlessonRepository.GetMasterLessonById(id.Value);
            if (masterlesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.Master = masterRepository.GetAllMasters();
            return View(masterlesson);
        }

        // POST: Admin1/MasterLessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            masterlessonRepository.DeleteMasterLesson(id);
            masterlessonRepository.save();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.Master = masterRepository.GetAllMasters();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                masterlessonRepository.Dispose();
                db.Dispose();
            }

        }


        public ActionResult AddLesson(int Id, int Master)
        {
            int i = 0;
            foreach (var Masterlesson in masterlessonRepository.GetAllMasterLessons())
            {
                if (Masterlesson.MasterCode == Master && Masterlesson.LessonCode == Id)
                {
                    return RedirectToAction("Delete", Masterlesson.MasterLessonId);
                }
            }

            if (i == 0)
            {
                MasterLesson Add = new MasterLesson()
                {
                    MasterCode = Master,
                    LessonCode = Id,
                    Prefer = 10
                };
                masterlessonRepository.InsertMasterLesson(Add);
                masterlessonRepository.save();
            }
            return RedirectToAction("Index", Master);
        }


        public ActionResult DeleteLesson(int Id)
        {
            int Ma = 0;
            foreach (var Masterlesson in masterlessonRepository.GetAllMasterLessons())
            {
                if (Masterlesson.MasterLessonId == Id)
                {
                    masterlessonRepository.DeleteMasterLesson(Masterlesson);
                    Ma = Masterlesson.MasterCode;
                }
            }
            masterlessonRepository.save();
            return RedirectToAction("Index",Ma);
        }
    }
}
