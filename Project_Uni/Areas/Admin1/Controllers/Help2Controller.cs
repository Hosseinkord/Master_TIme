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
    public class Help2Controller : Controller
    {
        private ILoginRepository loginRepository;
        private ICal_EndRepository cal_endRepository;
        private IEnterRepository enterRepository;
        private IMasterRepository masterRepository;
        private IHelp2Repository help2Repository;
        private IHelpRepository helpRepository;
        private IDateRepository dateRepository;
        private IMasterDateRepository masterdateRepository;
        private IMasterLessonRepository masterlessonRepository;
        private ILessonRepository lessonRepository;

        Pr_UniContext db = new Pr_UniContext();
        public Help2Controller()
        {
            loginRepository = new LoginRepository(db);
            cal_endRepository = new Cal_EndRepository(db);
            enterRepository = new EnterRepository(db);
            masterRepository = new MasterRepository(db);
            help2Repository = new Help2Repository(db);
            helpRepository = new HelpRepository(db);
            masterdateRepository = new MasterDateRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            dateRepository = new DateRepository(db);
            lessonRepository = new LessonRepository(db);
        }

        // GET: Admin1/Helps
        public ActionResult Index()
        {
            ViewBag.Cal = cal_endRepository.GetAllCal_Ends();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            ViewBag.MasterDate = masterdateRepository.GetAllMasterDates();
            ViewBag.MasterLesson = masterlessonRepository.GetAllMasterLessons();
            ViewBag.Help = helpRepository.GetAllHelps();
            ViewBag.Help2 = help2Repository.GetAllHelp2s();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            return View(help2Repository.GetAllHelp2s());
        }

        // GET: Admin1/Help2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help2 help2 = db.Help2s.Find(id);
            if (help2 == null)
            {
                return HttpNotFound();
            }
            return View(help2);
        }

        // GET: Admin1/Help2/Create
        public ActionResult Create()
        {
            ViewBag.Login = loginRepository.GetAllLogins();
            ViewBag.Cal = cal_endRepository.GetAllCal_Ends();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            ViewBag.MasterDate = masterdateRepository.GetAllMasterDates();
            ViewBag.MasterLesson = masterlessonRepository.GetAllMasterLessons();
            ViewBag.Help = helpRepository.GetAllHelps();
            ViewBag.Help2 = help2Repository.GetAllHelp2s();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            return View();
        }

        // POST: Admin1/Help2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Help2Id,DateId,MasterCode,LessonCode,ScHelp")] Help2 help2)
        {
            int[] MD3 =new int[500];
            int[] MD4 =new int[500];
            int[] MD5 =new int[500];
            int[] MD6 =new int[500];
            int[] MD7 = new int[500];

            int h = 0;
            int k = 0;

            for (int H = 0; H < 200; H++)
            {
                help2.DateId = 0;
                help2.LessonCode = 0;
                help2.MasterCode= 0;
                help2.ScHelp = 0;
                help2Repository.InsertHelp2(help2);
                help2Repository.save();
            }

            foreach (var ite in helpRepository.GetAllHelps())
            {
                foreach (var item in masterlessonRepository.GetAllMasterLessons())
                {
                    if (ite.MC == item.MasterCode)
                    {
                        MD3[h] = ite.DI;
                        MD4[h] = ite.MC;
                        MD5[h] = item.LessonCode;
                        MD6[h] = item.Prefer;
                        MD7[h] = ite.ST;
                        h++;
                    }
                }
            }


            foreach (var item in help2Repository.GetAllHelp2s())
            {
                if (k < h)
                {
                    item.MasterCode = MD4[k];
                    item.LessonCode = MD5[k];
                    item.ScHelp = MD6[k];
                    item.DateId = MD3[k];
                    item.ScHelp = MD7[k];
                    k++;
                }
                else
                {
                    help2Repository.DeleteHelp2(item.Help2Id);
                }
            }
            int Ol = 10;
            foreach(var item in help2Repository.GetAllHelp2s())
            {
                item.ScHelp = Ol - item.ScHelp;
                foreach(var ite in lessonRepository.GetAllLessons())
                {
                    if(item.LessonCode==ite.LessonCode)
                    {
                        item.ScHelp += ite.Score;
                    }
                }
            }

            foreach(var item in help2Repository.GetAllHelp2s())
            {
                foreach (var ite in lessonRepository.GetAllLessons())
                {
                    if(item.LessonCode==ite.LessonCode)
                    {
                        foreach (var it in enterRepository.GetAllEnters())
                        {
                            if (ite.Term % 2 == it.NumTerm)
                            {
                                item.ScHelp += 4;
                            }
                        }
                    }
                }
            }

            foreach (var item in help2Repository.GetAllHelp2s())
            {
                foreach (var ite in masterdateRepository.GetAllMasterDates())
                {
                    if (item.MasterCode == ite.MasterCode)
                    {
                       if (ite.Status==1)
                            {
                                item.ScHelp += 1;
                            }
                    }
                }
            }

            if (ModelState.IsValid)
                {
                    help2Repository.save();
                    return RedirectToAction("Create");
                }

                return View(help2);
            }

        // GET: Admin1/Help2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help2 help2 = db.Help2s.Find(id);
            if (help2 == null)
            {
                return HttpNotFound();
            }
            return View(help2);
        }

        // POST: Admin1/Help2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Help2Id,DateId,MasterCode,LessonCode,ScHelp")] Help2 help2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(help2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(help2);
        }

        // GET: Admin1/Help2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help2 help2 = db.Help2s.Find(id);
            if (help2 == null)
            {
                return HttpNotFound();
            }
            return View(help2);
        }

        // POST: Admin1/Help2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Help2 help2 = db.Help2s.Find(id);
            db.Help2s.Remove(help2);
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

        // GET: Admin1/Helps
        public ActionResult Tree()
        {
            ViewBag.Login = loginRepository.GetAllLogins();
            ViewBag.Cal = cal_endRepository.GetAllCal_Ends();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            ViewBag.MasterDate = masterdateRepository.GetAllMasterDates();
            ViewBag.MasterLesson = masterlessonRepository.GetAllMasterLessons();
            ViewBag.Help = helpRepository.GetAllHelps();
            ViewBag.Help2 = help2Repository.GetAllHelp2s();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            return View(help2Repository.GetAllHelp2s());
        }

        public ActionResult Finish()
        {
            ViewBag.Cal = cal_endRepository.GetAllCal_Ends();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Date = dateRepository.GetAllDates();
            ViewBag.MasterDate = masterdateRepository.GetAllMasterDates();
            ViewBag.MasterLesson = masterlessonRepository.GetAllMasterLessons();
            ViewBag.Help = helpRepository.GetAllHelps();
            ViewBag.Help2 = help2Repository.GetAllHelp2s();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            return View(help2Repository.GetAllHelp2s());
        }
    }
}
