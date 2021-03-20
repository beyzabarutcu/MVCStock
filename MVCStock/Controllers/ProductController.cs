using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MVCStokEntities1 db = new MVCStokEntities1();

        public ActionResult Index()
        {
            var products = db.Products.ToList();          
            return View(products);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> items = (from i in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.CategoryID.ToString()
                                          }).ToList();
            ViewBag.dgr = items;
            return View();
        }
        [HttpPost]        
        public ActionResult Add(Products p1)
        {
            var ctg = db.Categories.Where(m => m.CategoryID == p1.Categories.CategoryID).FirstOrDefault();
            p1.Categories = ctg;
            db.Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductFind(int id)
        {
            var product = db.Products.Find(id);

            List<SelectListItem> items = (from i in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.CategoryID.ToString()
                                          }).ToList();
            ViewBag.dgr = items;

            return View("Update", product);
        }

        public ActionResult Update(Products p)
        {
            var product = db.Products.Find(p.ProductID);
            product.ProductName = p.ProductName;
            product.Brand = p.Brand;
            product.Price = p.Price;
            product.Stock = p.Stock;
            // product.ProductCategory = p.ProductCategory;
            var ctg = db.Categories.Where(m => m.CategoryID == p.Categories.CategoryID).FirstOrDefault();
            product.ProductCategory = ctg.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}