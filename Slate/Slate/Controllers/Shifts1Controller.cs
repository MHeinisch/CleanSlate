using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Slate.Models;

namespace Slate.Controllers
{
    public class Shifts1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shifts1
        public async Task<ActionResult> Index()
        {
            return View(await db.shift.ToListAsync());
        }

        // GET: Shifts1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = await db.shift.FindAsync(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // GET: Shifts1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shifts1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ShiftId,TimeOfDay,WeekDay")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.shift.Add(shift);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(shift);
        }

        // GET: Shifts1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = await db.shift.FindAsync(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shifts1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ShiftId,TimeOfDay,WeekDay")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shift).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shift);
        }

        // GET: Shifts1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = await db.shift.FindAsync(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shifts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Shift shift = await db.shift.FindAsync(id);
            db.shift.Remove(shift);
            await db.SaveChangesAsync();
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
