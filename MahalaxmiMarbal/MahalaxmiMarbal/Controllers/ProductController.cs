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
        private Mahalaxmi_MarbelsEntities _Context = new Mahalaxmi_MarbelsEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
       
        //GET: All Product Deatils Code Here
        [HttpGet]
        public ActionResult AllProductsDetails()
        {
            return View(_Context.Table_Product.ToList());
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
                obj.CreatedDate = DateTime.Now.ToString();
                obj.UpdatedDate = DateTime.Now.ToString();
                _Context.Table_Product.Add(obj);
                _Context.SaveChanges();

                return RedirectToAction("AllProductsDetails");
            }
            catch
            {
                return View();
            }

        }
        /// <summary>
        /// get product by id for show single product details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            try
            {
                Table_Product obj = _Context.Table_Product.Find(id);
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

            Table_Product student = _Context.Table_Product.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);

        }

        [HttpPost]
        public ActionResult UpdateProduct(Table_Product obj)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    obj.UpdatedDate = DateTime.Now.ToString();
                    _Context.Entry(obj).State = EntityState.Modified;
                    _Context.SaveChanges();
                    return RedirectToAction("AllProductsDetails");
                }
                return View(obj);

            }
            catch
            {
                return View();
            }

        }
    }
}