using MahalaxmiMarbal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahalaxmiMarbal.Controllers
{
    public class SubProductController : Controller
    {
        private Mahalaxmi_MarbelsEntities _Context = new Mahalaxmi_MarbelsEntities();
        // GET: SubProduct
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Sub Product List for product Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AllSubProductById(int? id)
        {
            if (id != null)
            {
                var AllSubProductByIdList = _Context.Table_ProductDetails.Where(a => a.ProductId == id).ToList();
                return View(AllSubProductByIdList);
            }
            else
            {
                return RedirectToAction("AllProductsDetails", "Product");
            }
        }
        #region add product
        [HttpGet]
        public ActionResult AddSubProduct(int? id)
        {
            var items = _Context.Table_Vendor_Registration.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }
            ViewBag.ProductId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddSubProduct(Table_ProductDetails obj)
        {
            try
            {
                obj.CreatedDate = DateTime.Now.ToString();
                obj.UpdatedDate = DateTime.Now.ToString();
                _Context.Table_ProductDetails.Add(obj);
                _Context.SaveChanges();
                return RedirectToAction("AllSubProductById", new {obj.ProductId });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        [HttpGet]
        public ActionResult Details(int id)
        {
            var SubProductById = _Context.Table_ProductDetails.Where(a => a.Id == id).FirstOrDefault();
            return View(SubProductById);
        }

        #region Update Sub Product
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var SubProductById = _Context.Table_ProductDetails.Where(a => a.Id == id).FirstOrDefault();
            return View(SubProductById);
        }
        [HttpPost]
        public ActionResult Edit(Table_ProductDetails obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.UpdatedDate = DateTime.Now.ToString();
                    _Context.Entry(obj).State = EntityState.Modified;
                    _Context.SaveChanges();
                    return RedirectToAction("AllSubProductById", new { id= obj.Id});
                }
                return View(obj);
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}