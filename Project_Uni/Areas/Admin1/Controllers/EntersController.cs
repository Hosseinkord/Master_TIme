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
    public class EntersController : Controller
    {

        private IEnterRepository enterRepository;

        Pr_UniContext db = new Pr_UniContext();
        public EntersController()
        {
            enterRepository = new EnterRepository(db);
        }

      
        // GET: Admin1/Enters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enter enter = enterRepository.GetEnterById(id.Value);
            if (enter == null)
            {
                return HttpNotFound();
            }
            return View(enter);
        }

        // POST: Admin1/Enters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnterId,startTime,EndTime,NumTerm,NumClass")] Enter enter)
        {
            if (ModelState.IsValid)
            {
                enterRepository.UpdateEnter(enter);
                enterRepository.save();
                return Redirect("/Admin1/Help2/Create");
            }
            return View(enter);
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
