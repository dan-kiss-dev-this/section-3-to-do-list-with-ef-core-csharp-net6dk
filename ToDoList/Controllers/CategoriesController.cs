using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ToDoListContext _db;

        public CategoriesController(ToDoListContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Category> model = _db.Categories.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            // Add is a DBSet method we run on our DBSet property of ToDoListContext while SaveChange() is a DbContext method that we run on the ToDoListContext itself
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            // look in items table
            Category thisCategory = _db.Categories
            .Include(category => category.Items)
            .FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }

        public ActionResult Edit(int id)
        {
            Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
            _db.Categories.Remove(thisCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}