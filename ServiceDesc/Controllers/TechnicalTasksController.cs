using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceDesc.Models;

namespace ServiceDesc.Controllers
{
    public class TechnicalTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TechnicalTasks
        public async Task<ActionResult> Index()
        {
            return View(await db.TechnicalTasks.ToListAsync());
        }

        // GET: TechnicalTasks/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalTask technicalTask = await db.TechnicalTasks.FindAsync(id);
            if (technicalTask == null)
            {
                return HttpNotFound();
            }
            return View(technicalTask);
        }

        // GET: TechnicalTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicalTasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CreationDate,Cabinet,Comment,IsComplete")] TechnicalTask technicalTask)
        {
            if (ModelState.IsValid)
            {
                technicalTask.Id = Guid.NewGuid();
                db.TechnicalTasks.Add(technicalTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(technicalTask);
        }

        // GET: TechnicalTasks/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalTask technicalTask = await db.TechnicalTasks.FindAsync(id);
            if (technicalTask == null)
            {
                return HttpNotFound();
            }
            return View(technicalTask);
        }

        // POST: TechnicalTasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CreationDate,Cabinet,Comment,IsComplete")] TechnicalTask technicalTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicalTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(technicalTask);
        }

        // GET: TechnicalTasks/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalTask technicalTask = await db.TechnicalTasks.FindAsync(id);
            if (technicalTask == null)
            {
                return HttpNotFound();
            }
            return View(technicalTask);
        }

        // POST: TechnicalTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TechnicalTask technicalTask = await db.TechnicalTasks.FindAsync(id);
            db.TechnicalTasks.Remove(technicalTask);
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
