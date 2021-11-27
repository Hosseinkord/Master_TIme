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
    public class LessonsController : Controller
    {
        private IMasterRepository masterRepository;
        private ILoginRepository loginRepository;
        private ILEHeRepository leheRepository;
        private IMasterLessonRepository masterlessonRepository;
        private ILessonRepository lessonRepository;
        Pr_UniContext db = new Pr_UniContext();
        public LessonsController()
        {
            masterRepository = new MasterRepository(db);
            loginRepository = new LoginRepository(db);
            leheRepository = new LEHeRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            lessonRepository = new LessonRepository(db);
        }

        // GET: Admin1/Lessons
        public ActionResult Index()
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Login = loginRepository.GetAllLogins();
            return View(lessonRepository.GetAllLessons());
        }

        // GET: Admin1/Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Admin1/Lessons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin1/Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonId,LessonCode,LessonGroup,LessonName,Unit,Term,Score")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                foreach (var LEs in lessonRepository.GetAllLessons())
                {
                    if(lesson.LessonCode==LEs.LessonCode)
                    {
                        return Redirect("http://localhost:61776/Admin1/Lessons/Error");
                    }
                }
                LEHe le = new LEHe()
                {
                    LessonCode = lesson.LessonCode,
                    LessonGroup = lesson.LessonGroup,
                    LUnit=lesson.Unit
                };
                leheRepository.InsertLEHe(le);

                leheRepository.save();
                lessonRepository.InsertLesson(lesson);
                lessonRepository.save();
                return RedirectToAction("Index");
            }

            return Redirect("http://localhost:61776/Admin1/Lessons/Error");
        }

        // GET: Admin1/Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Admin1/Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonId,LessonCode,LessonGroup,LessonName,Unit,Term,Score")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                foreach (var LE in leheRepository.GetAllLEHes())
                {
                    if (LE.LessonCode == lesson.LessonCode)
                    {
                        LE.LessonCode = lesson.LessonCode;
                        LE.LessonGroup = lesson.LessonGroup;
                        LE.LUnit = lesson.Unit;
                    }
                }

                leheRepository.save();
                lessonRepository.UpdateLesson(lesson);
                lessonRepository.save();
                return RedirectToAction("Index");
            }
            return Redirect("http://localhost:61776/Admin1/Lessons/Error");
        }

        // GET: Admin1/Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Admin1/Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int lc = 0;
            foreach (var hp in lessonRepository.GetAllLessons())
            {
                if (hp.LessonId == id)
                {
                    lc = hp.LessonCode;
                }
            }
            foreach (var MasterDate in masterlessonRepository.GetAllMasterLessons())
            {
                if (MasterDate.LessonCode == lc)
                {
                    masterlessonRepository.DeleteMasterLesson(MasterDate);
                }
            }

            foreach (var LE in leheRepository.GetAllLEHes())
            {
                if(LE.LessonCode==lc)
                {
                    leheRepository.DeleteLEHe(LE);
                }
            }

            lessonRepository.DeleteLesson(id);
            lessonRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lessonRepository.Dispose();
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
