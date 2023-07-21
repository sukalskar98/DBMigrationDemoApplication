using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoApplication.Models;

namespace DemoApplication.Controllers
{
    public class TestModelsController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: TestModels
        public ActionResult Index()
        {
            var x = db.GetTable<TestModel>().FirstOrDefault();
            return View(x);
        }

        // GET: TestModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testModel = db.GetTable<TestModel>().FirstOrDefault(x => x.ID == id);
            if (testModel == null)
            {
                return HttpNotFound();
            }
            return View(testModel);
        }

        //// GET: TestModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TestModels/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Description,CreatedDate")] TestModel testModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TestModels.Add(testModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(testModel);
        //}

        //// GET: TestModels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TestModel testModel = db.TestModels.Find(id);
        //    if (testModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(testModel);
        //}

        //// POST: TestModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Description,CreatedDate")] TestModel testModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(testModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(testModel);
        //}

        //// GET: TestModels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TestModel testModel = db.TestModels.Find(id);
        //    if (testModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(testModel);
        //}

        //// POST: TestModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TestModel testModel = db.TestModels.Find(id);
        //    db.TestModels.Remove(testModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
