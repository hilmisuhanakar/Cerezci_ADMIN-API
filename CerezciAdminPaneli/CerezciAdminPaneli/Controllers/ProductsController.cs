using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Data.Entity;
using System.IO;

namespace CerezciProjeciAdminPaneli.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {

        CerezciDbContext db = new CerezciDbContext();

        // GET: Products       

        public ActionResult Index()
        {
            return View(db.Products.OrderBy(x => x.ProductName).ToList());
        }

        
        // GET: Products/Details/5
        public ActionResult Details(int Id)
        {
            return View(db.Products.Find(Id));
        }

        
        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Products Product)
        {

            if (Request.Files.Count > 0)
            {
                var image = Path.GetFileName(Request.Files[0].FileName);
                var path = "~/Images/" + image;
                Request.Files[0].SaveAs(Server.MapPath(path));
                Product.ProductImage = "/Images/" + image;
            }
            db.Products.Add(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            return View(db.Products.Find(Id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Products Product)
        {
            if (Request.Files.Count > 0)
            {
                var image = Path.GetFileName(Request.Files[0].FileName);
                var path = "~/Images/" + image;
                Request.Files[0].SaveAs(Server.MapPath(path));
                Product.ProductImage = "/Images/" + image;
            }
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        // GET: Products/Delete/5
        public ActionResult Delete(int? Id)
        {
            return View(db.Products.Find(Id));
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            db.Products.Remove(db.Products.Find(Id));
            db.SaveChanges();
            return RedirectToAction("Index"); ;
        }
    }
}
