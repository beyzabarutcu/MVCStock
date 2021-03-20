using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;
namespace MVCStock.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MVCStokEntities1 db = new MVCStokEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(Sales p1)
        {
            db.Sales.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}