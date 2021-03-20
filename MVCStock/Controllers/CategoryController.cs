using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MVCStokEntities1 db = new MVCStokEntities1();

        public ActionResult Index(int page=1)
        {
            //var categories = db.Categories.ToList();
            var categories = db.Categories.ToList().ToPagedList(page, 4);
            return View(categories);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Categories p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Categories.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryFind(int id)
        {
            var ctgr = db.Categories.Find(id);
            return View("Update", ctgr);
        }

        public ActionResult Update(Categories p1)
        {
            var category = db.Categories.Find(p1.CategoryID);
            category.CategoryName = p1.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}