using homework_56.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_56.Controllers
{
    public class TasksController : Controller
    {
        private ToDoContext _db;

        public TasksController(ToDoContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tasks = _db.Tasks.ToList();
            return View(tasks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
            task.CreateDate = DateTime.Now;
            task.Status = "Новая";
            if (task != null)
            {
                _db.Tasks.Add(task);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Deitels(int Id)
        {
            var task = _db.Tasks.FirstOrDefault(t => t.id == Id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var task = _db.Tasks.FirstOrDefault(t => t.id == Id);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Close(int Id)
        {
            var task = _db.Tasks.FirstOrDefault(t => t.id == Id);
            task.ComplateDate = DateTime.Now;
            task.Status = "Закрыто";
            _db.Tasks.Update(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Open(int Id)
        {
            var task = _db.Tasks.FirstOrDefault(t => t.id == Id);
            task.OpenDate = DateTime.Now;
            task.Status = "Открыта";
            _db.Tasks.Update(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
