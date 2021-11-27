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
    public class Cal_EndController : Controller
    {
        private ILoginRepository loginRepository;
        private ILEHeRepository leheRepository;
        private IMEHeRepository maheRepository;
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
        public Cal_EndController()
        {
            loginRepository = new LoginRepository(db);
            leheRepository = new LEHeRepository(db);
            maheRepository = new MAHeRepository(db);
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
        // GET: Admin1/Cal_End
        public ActionResult Index()
        {
            ViewBag.Login = loginRepository.GetAllLogins();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.ClaEnd = cal_endRepository.GetAllCal_Ends();
            ViewBag.Date = dateRepository.GetAllDates();
            return View(cal_endRepository.GetAllCal_Ends());
        }

        // GET: Admin1/Cal_End/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_End cal_End = db.Cal_Ends.Find(id);
            if (cal_End == null)
            {
                return HttpNotFound();
            }
            return View(cal_End);
        }

        // GET: Admin1/Cal_End/Create
        public ActionResult Create()
        {
            ViewBag.Login = loginRepository.GetAllLogins();
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.ClaEnd = cal_endRepository.GetAllCal_Ends();
            ViewBag.Date = dateRepository.GetAllDates();
            return View();
        }

        // POST: Admin1/Cal_End/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cal_EndId,Time,Master,Lesson,Number")] Cal_End cal_End)
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.ClaEnd = cal_endRepository.GetAllCal_Ends();
            ViewBag.Date = dateRepository.GetAllDates();

            int j = 1;
            int i = 0;
            int h = 0;
            int Mas = 0;

            int[] MD1 = new int[500];
            int[] MD2 = new int[500];
            int[] MD3 = new int[500];
            int[] MD4 = new int[500];
            int[] MD5 = new int[2000];
            for (int k = 0; k < 200; k++)
            {
                cal_End.Lesson = 0;
                cal_End.Master = 0;
                cal_End.Number = 0;
                cal_End.Time = 0;
                cal_endRepository.InsertCal_End(cal_End);
                cal_endRepository.save();
            }
            int sc = 0;

            foreach (var D in dateRepository.GetAllDates())
            {
                sc = 0;
                Mas = 0;
                j = 1;
                foreach (var Hel in help2Repository.GetAllHelp2s().OrderByDescending(gl => gl.ScHelp))
                {
                    if (D.DateId == Hel.DateId)
                    {
                        sc = Hel.ScHelp;
                        MD1[i] = D.DateId;
                        MD2[i] = Hel.MasterCode;
                        MD3[i] = Hel.LessonCode;
                        MD4[i] = j;
                        Mas = Hel.MasterCode;
                        j++;
                        i++;
                    }
                }
            }

            int maxNum = 0;

            foreach (var cal in cal_endRepository.GetAllCal_Ends())
            {
                if (MD1[h] != 0)
                {
                    cal.Time = MD1[h];
                    cal.Lesson = MD3[h];
                    cal.Master = MD2[h];
                    cal.Number = MD4[h];
                    h++;
                    if (MD4[h] > maxNum)
                    {
                        maxNum = MD4[h];
                    }
                }
                else
                {
                    break;
                }
            }

            ///**************************************
            ///
            foreach (var lehe in leheRepository.GetAllLEHes())
            {
                leheRepository.DeleteLEHe(lehe);
            }
            foreach (var le in lessonRepository.GetAllLessons())
            {
                LEHe lehe = new LEHe()
                {
                    LessonCode = le.LessonCode,
                    LessonGroup = le.LessonGroup,
                    LUnit = le.Unit
                };
                leheRepository.InsertLEHe(lehe);
            }
            ///*******************************************
            ///
            foreach (var mahe in maheRepository.GetAllMAHes())
            {
                maheRepository.DeleteMAHe(mahe);
            }
            foreach (var ma in masterRepository.GetAllMasters())
            {
                MAHe mehe = new MAHe()
                {
                    MasterCode=ma.MasterCode,
                    NumLesson=ma.NumLesson
                };
                maheRepository.InsertMAHe(mehe);
            }





            //************************************************************
            ////************************************************************
            ////*******************************************************************************
            //int[] les5 = new int[400];//تعریف متغییر برای ذخیره درس
            //int[] mast5 = new int[400];//تعریف متغیر برای ذخیره استاد
            //int[] num5 = new int[400];//تعریف متغیر برای ذخیره تعداد
            //int[] roz5 = new int[400];//تعریف متغیر برای ذخیره روز
            //int[] Id5 = new int[400];//تعریف متغیر برای ذخیره آیدی
            ////*******************************************************************************
            //int[] les6 = new int[400];//تعریف متغییر برای ذخیره درس
            //int[] mast6 = new int[400];//تعریف متغیر برای ذخیره استاد
            //int[] num6 = new int[400];//تعریف متغیر برای ذخیره تعداد
            //int[] roz6 = new int[400];//تعریف متغیر برای ذخیره روز
            //int[] Id6 = new int[400];//تعریف متغیر برای ذخیره آیدی

            //bool Flag2 = false;//پرچم برای اجازه ذخیره سازی
            //int l5 = 0;
            //int l6 = 0;



            //foreach (var cal in cal_endRepository.GetAllCal_Ends())//جستجو در کل جدول که برحسب امتیازات نمره داده شده است.
            //{
            //    Flag2 = false;//پرچم برای اجازه ذخیره سازی

            //    if (cal.Time == 0)
            //    {
            //        break;
            //    }

            //    else if (cal.Number == 3)//سطرهایی که امتیاز شماره 2 را دارند
            //    {
            //        for (int v = 0; v < l5; v++)
            //        {
            //            if (cal.Master == mast5[v] && cal.Lesson == les5[v] && num5[v] == 1)
            //            {
            //                les6[l6] = cal.Lesson;
            //                mast6[l6] = cal.Master;
            //                num6[l6] = 2;
            //                roz6[l6] = cal.Time;
            //                Id6[l6] = cal.Cal_EndId;
            //                num5[v] = 2;
            //                Flag2 = true;
            //                l6++;
            //            }

            //            else if (cal.Master == mast5[v] && cal.Lesson == les5[v] && num5[v] == 2)
            //            {
            //                Flag2 = true;
            //            }
            //        }
            //        if (Flag2 == false)
            //        {
            //            les5[l5] = cal.Lesson;
            //            mast5[l5] = cal.Master;
            //            num5[l5] = 1;
            //            roz5[l5] = cal.Time;
            //            Id5[l5] = cal.Cal_EndId;
            //            l5++;
            //        }
            //    }
            //}
            //int o3 = 0;
            //for (int c = l5; c <= l5 + l6; c++)
            //{
            //    les5[c] = les6[o3];
            //    mast5[c] = mast6[o3];
            //    num5[c] = num6[o3];
            //    roz5[c] = roz6[o3];
            //    Id5[c] = Id6[o3];
            //    o3++;
            //}
            ////*******************************************
            ////*******************************************************************************


            ////************************************************************
            ////************************************************************
            ////*******************************************************************************
            //int[] les3 = new int[400];//تعریف متغییر برای ذخیره درس
            //int[] mast3 = new int[400];//تعریف متغیر برای ذخیره استاد
            //int[] num3 = new int[400];//تعریف متغیر برای ذخیره تعداد
            //int[] roz3 = new int[400];//تعریف متغیر برای ذخیره روز
            //int[] Id3 = new int[400];//تعریف متغیر برای ذخیره آیدی
            ////*******************************************************************************
            //int[] les4 = new int[400];//تعریف متغییر برای ذخیره درس
            //int[] mast4 = new int[400];//تعریف متغیر برای ذخیره استاد
            //int[] num4 = new int[400];//تعریف متغیر برای ذخیره تعداد
            //int[] roz4 = new int[400];//تعریف متغیر برای ذخیره روز
            //int[] Id4 = new int[400];//تعریف متغیر برای ذخیره آیدی

            //bool Flag1 = false;//پرچم برای اجازه ذخیره سازی
            //int l3 = 0;
            //int l4 = 0;



            //foreach (var cal in cal_endRepository.GetAllCal_Ends())//جستجو در کل جدول که برحسب امتیازات نمره داده شده است.
            //{
            //    Flag1 = false;//پرچم برای اجازه ذخیره سازی

            //    if (cal.Time == 0)
            //    {
            //        break;
            //    }

            //    else if (cal.Number == 2)//سطرهایی که امتیاز شماره 2 را دارند
            //    {
            //        for (int v = 0; v < l3; v++)
            //        {
            //            if (cal.Master == mast3[v] && cal.Lesson == les3[v] && num3[v] == 1)
            //            {
            //                les4[l4] = cal.Lesson;
            //                mast4[l4] = cal.Master;
            //                num4[l4] = 2;
            //                roz4[l4] = cal.Time;
            //                Id4[l4] = cal.Cal_EndId;
            //                num3[v] = 2;
            //                Flag1 = true;
            //                l4++;
            //            }

            //            else if (cal.Master == mast3[v] && cal.Lesson == les3[v] && num3[v] == 2)
            //            {
            //                Flag1 = true;
            //            }
            //        }
            //        if (Flag1 == false)
            //        {
            //            les3[l3] = cal.Lesson;
            //            mast3[l3] = cal.Master;
            //            num3[l3] = 1;
            //            roz3[l3] = cal.Time;
            //            Id3[l3] = cal.Cal_EndId;
            //            l3++;
            //        }
            //    }
            //}
            //int o1 = 0;
            //for (int c = l3; c <= l3 + l4; c++)
            //{
            //    les3[c] = les4[o1];
            //    mast3[c] = mast4[o1];
            //    num3[c] = num4[o1];
            //    roz3[c] = roz4[o1];
            //    Id3[c] = Id4[o1];
            //    o1++;
            //}
            //*******************************************
            //*******************************************************************************
            int[] les = new int[400];//تعریف متغییر برای ذخیره درس
            int[] mast = new int[400];//تعریف متغیر برای ذخیره استاد
            int[] num = new int[400];//تعریف متغیر برای ذخیره تعداد
            int[] roz = new int[400];//تعریف متغیر برای ذخیره روز
            int[] Id = new int[400];//تعریف متغیر برای ذخیره آیدی
            //*******************************************************************************
            int[] les2 = new int[400];//تعریف متغییر برای ذخیره درس
            int[] mast2 = new int[400];//تعریف متغیر برای ذخیره استاد
            int[] num2 = new int[400];//تعریف متغیر برای ذخیره تعداد
            int[] roz2 = new int[400];//تعریف متغیر برای ذخیره روز
            int[] Id2 = new int[400];//تعریف متغیر برای ذخیره آیدی

            bool Flag = false;//پرچم برای اجازه ذخیره سازی
            int l = 0;
            int l2 = 0;
            bool f = true;
            bool nummax = false;

            foreach (var cal in cal_endRepository.GetAllCal_Ends())//جستجو در کل جدول که برحسب امتیازات نمره داده شده است.
            {
                f = true;
                Flag = false;//پرچم برای اجازه ذخیره سازی


                for (int s = 0; s < maxNum; s++)
                {
                    if (cal.Number == s)
                    {
                        nummax = true;
                    }
                }

                if (cal.Time == 0)
                {
                    break;
                }

                else if (nummax==true)//سطرهایی که امتیاز شماره 1 را دارند
                {
                    for (int v = 0; v < l; v++)
                    {
                        if (cal.Master == mast[v] && cal.Lesson == les[v] && num[v] == 1)
                        {
                            les2[l2] = cal.Lesson;
                            mast2[l2] = cal.Master;
                            num2[l2] = 2;
                            roz2[l2] = cal.Time;
                            Id2[l2] = cal.Cal_EndId;
                            num[v] = 2;
                            Flag = true;
                            l2++;


                            foreach (var le in leheRepository.GetAllLEHes())
                            {
                                if(le.LessonCode== cal.Lesson)
                                {
                                    cal.Count = le.LUnit;
                                    le.LessonGroup -= 1;
                                }
                            }

                            foreach (var ma in  maheRepository.GetAllMAHes())
                            {
                                if(ma.MasterCode == cal.Master)
                                {
                                    ma.NumLesson -= cal.Count;
                                }
                            }
                        }

                        else if (cal.Master == mast[v] && cal.Lesson == les[v] && num[v] == 2)
                        {
                            Flag = true;
                        }
                    }
                    if(Flag==false)
                    {
                        foreach (var le in leheRepository.GetAllLEHes())
                        {
                            if (cal.Lesson == le.LessonCode && le.LessonGroup != 0)
                            {
                                foreach (var ma in maheRepository.GetAllMAHes())
                                {
                                    if (ma.MasterCode == cal.Master && ma.NumLesson != 0)
                                    {
                                        for (int q = 0; q <= l; q++)
                                        {
                                            if (roz[q] == cal.Time && mast[q] == cal.Master)
                                            {
                                                f = false;
                                            }
                                        }
                                        if (f == true)
                                        {
                                        les[l] = cal.Lesson;
                                        mast[l] = cal.Master;
                                        num[l] = 1;
                                        roz[l] = cal.Time;
                                        Id[l] = cal.Cal_EndId;
                                        l++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //***************************************
            ///***************************************
            int o = 0;
            for (int c=l;  c<=l+l2; c++)
            {
                les[c] = les2[o];
                mast[c] = mast2[o];
                num[c] = num2[o];
                roz[c] = roz2[o];
                Id[c] = Id2[o];
                o++;
            }


            //int o2 = 0;
            //for (int c = l+l2; c <= l+l2+l3 + l4; c++)
            //{
            //    les[c] = les3[o2];
            //    mast[c] = mast3[o2];
            //    num[c] = num3[o2];
            //    roz[c] = roz3[o2];
            //    Id[c] = Id3[o2];
            //    o2++;
            //}


            //int o4 = 0;
            //for (int c = l + l2 + l3 + l4; c <= l + l2 + l3 + l4 + l5 + l6; c++)
            //{
            //    les[c] = les5[o4];
            //    mast[c] = mast5[o4];
            //    num[c] = num5[o4];
            //    roz[c] = roz5[o4];
            //    Id[c] = Id5[o4];
            //    o4++;
            //}

            //***********************************************
            int g = 0;
            foreach (var calend in cal_endRepository.GetAllCal_Ends())
            {
                if (mast[g] != 0)
                {
                    calend.Lesson = les[g];
                    calend.Master = mast[g];
                    calend.Time = roz[g];
                    calend.Number = num[g];
                    g++;
                }

                else if (mast[g] == 0)
                {
                    cal_endRepository.DeleteCal_End(calend);
                }
            }



            if (ModelState.IsValid)
            {
                maheRepository.save();
                leheRepository.save();
                masterRepository.save();
                lessonRepository.save();
                cal_endRepository.save();
                return RedirectToAction("Create");
            }

            return View(cal_End);
        }

        // GET: Admin1/Cal_End/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_End cal_End = db.Cal_Ends.Find(id);
            if (cal_End == null)
            {
                return HttpNotFound();
            }
            return View(cal_End);
        }

        // POST: Admin1/Cal_End/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cal_EndId,Time,Master,Lesson,Number")] Cal_End cal_End)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cal_End).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cal_End);
        }

        // GET: Admin1/Cal_End/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_End cal_End = db.Cal_Ends.Find(id);
            if (cal_End == null)
            {
                return HttpNotFound();
            }
            return View(cal_End);
        }

        // POST: Admin1/Cal_End/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cal_End cal_End = db.Cal_Ends.Find(id);
            db.Cal_Ends.Remove(cal_End);
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
