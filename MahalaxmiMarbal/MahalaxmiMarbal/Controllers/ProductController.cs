using MahalaxmiMarbal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahalaxmiMarbal.Controllers
{
    public class ProductController : Controller
    {
        private Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        //GET: All Product Deatils Code Here
        [HttpGet]
        public ActionResult AllProductsDetails()
        {
            using (Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities())
            {
                return View(model.Table_Product.ToList());
            }

        }
        //GET: All Product Deatils Code Here
        [HttpGet]
        public ActionResult AllSubProductsDetails(int id)
        {
            ViewBag.UserName = new SelectList(model.Table_Product.Where(b => b.Product_id == id).ToList());
            return View();
            
        }
        //Get: Insert Product Code
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Table_Product obj)
        {
            try
            {
                using (Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities())
                {
                    model.Table_Product.Add(obj);
                    model.SaveChanges();
                }
                return RedirectToAction("AllProductsDetails");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            try
            {
                Table_Product obj = model.Table_Product.Find(id);
                if (obj == null)
                {
                    return HttpNotFound();
                }
                return View(obj);
            }
            catch
            {
                return View();
            }
        }
        //Get: Update Product Code
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            using (Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities())
            {
                Table_Product student = model.Table_Product.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(Table_Product obj)
        {
            try
            {
                using (Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities())
                {
                    if (ModelState.IsValid)
                    {
                        model.Entry(obj).State = EntityState.Modified;
                        model.SaveChanges();
                        return RedirectToAction("AllProductsDetails");
                    }
                    return View(obj);
                }
            }
            catch
            {
                return View();
            }

        }
    }
}