using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    public class RankController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Rank/

        public ActionResult Index()
        {
            var rankings = db.Rankings.Include(r => r.Category);
            return View(rankings.ToList());
        }

        //
        // GET: /Rank/Details/5

        public ActionResult Details(int id = 0)
        {
            Ranks ranks = db.Rankings.Find(id);
            if (ranks == null)
            {
                return HttpNotFound();
            }
            return View(ranks);
        }

        //
        // GET: /Rank/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        //
        // POST: /Rank/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ranks ranks)
        {
            if (ModelState.IsValid)
            {
                db.Rankings.Add(ranks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", ranks.CategoryId);
            return View(ranks);
        }

        //
        // GET: /Rank/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ranks ranks = db.Rankings.Find(id);
            if (ranks == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", ranks.CategoryId);
            return View(ranks);
        }

        //
        // POST: /Rank/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ranks ranks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ranks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", ranks.CategoryId);
            return View(ranks);
        }

        //
        // GET: /Rank/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ranks ranks = db.Rankings.Find(id);
            if (ranks == null)
            {
                return HttpNotFound();
            }
            return View(ranks);
        }

        //
        // POST: /Rank/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ranks ranks = db.Rankings.Find(id);
            db.Rankings.Remove(ranks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}