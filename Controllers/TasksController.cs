using homework_56.Enum;
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
        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Models.Task> productsB = _db.Tasks;
            ViewBag.NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewBag.PrioritySort = sortOrder == SortState.PriorityKeyAsc ? SortState.PriorityKeyDesc : SortState.PriorityKeyAsc;
            ViewBag.StatusSort = sortOrder == SortState.StatusKeyAsc ? SortState.StatusKeyDesc : SortState.StatusKeyAsc;
            ViewBag.CreateDateSort = sortOrder == SortState.CreateDateAsc ? SortState.CreateDateDesc : SortState.CreateDateAsc;
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    productsB = productsB.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriorityKeyAsc:

                    productsB = productsB.OrderBy(s => s.PriorityKey);

                    break;

                case SortState.PriorityKeyDesc:

                    productsB = productsB.OrderByDescending(s => s.PriorityKey);

                    break;

                case SortState.StatusKeyAsc:

                    productsB = productsB.OrderBy(s => s.StatusKey);

                    break;

                case SortState.StatusKeyDesc:

                    productsB = productsB.OrderByDescending(s => s.StatusKey);

                    break;
                case SortState.CreateDateAsc:

                    productsB = productsB.OrderBy(s => s.CreateDate);

                    break;
                case SortState.CreateDateDesc:

                    productsB = productsB.OrderByDescending(s => s.CreateDate);

                    break;

                default:

                    productsB = productsB.OrderBy(s => s.Name);

                    break;

            }

            return View(await productsB.AsNoTracking().ToListAsync());
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
            task.StatusKey = 1;
            if (task.Priority == "Высокий")
                task.PriorityKey = 1;
            else if(task.Priority == "Средний")
                task.PriorityKey = 2;
            else
                task.PriorityKey = 3;
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
        public IActionResult Open(int Id)
        {
            var task = _db.Tasks.FirstOrDefault(t => t.id == Id);
            task.OpenDate = DateTime.Now;
            task.Status = "Открыта";
            task.StatusKey = 2;
            _db.Tasks.Update(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Close(int Id)
        {
            var task = _db.Tasks.FirstOrDefault(t => t.id == Id);
            task.ComplateDate = DateTime.Now;
            task.Status = "Закрыто";
            task.StatusKey = 3;
            _db.Tasks.Update(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
