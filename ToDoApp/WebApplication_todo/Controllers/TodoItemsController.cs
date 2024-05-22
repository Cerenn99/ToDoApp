using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication_todo.Models;

namespace WebApplication_todo.Controllers
{
    public class TodoItemsController : Controller
    {
        private TodoAPPEntities db = new TodoAPPEntities();


        public ActionResult Index()
        {
            return View(db.TodoItem.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = db.TodoItem.Find(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,CreateDate,IsCompleted,Detail,Priority")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {

                todoItem.CreateDate = DateTime.Now;
                db.TodoItem.Add(todoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoItem);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = db.TodoItem.Find(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,CreateDate,IsCompleted,Detail,Priority")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = db.TodoItem.Find(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoItem todoItem = db.TodoItem.Find(id);
            db.TodoItem.Remove(todoItem);
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
        [HttpPost]
        public ActionResult UpdateCompleted(int Id, bool IsCompleted)
        {

            TodoAPPEntities db = new TodoAPPEntities();
            db.TodoItem.FirstOrDefault(i => i.Id == Id).IsCompleted = IsCompleted;
            db.SaveChanges();
            return Json(new { Id, IsCompleted });

        }



    }
}
