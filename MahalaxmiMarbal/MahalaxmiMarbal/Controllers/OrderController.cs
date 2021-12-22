using MahalaxmiMarbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahalaxmiMarbal.Controllers
{
    public class OrderController : Controller
    {
        private Mahalaxmi_MarbelsEntities _Context = new Mahalaxmi_MarbelsEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderList()
        {
            var OrderList = _Context.Table_OrderDeatils.OrderByDescending(a=>a.Id).ToList();
            return View(OrderList);
        }
        public ActionResult NewOrder()
        {
            var CustomerList = _Context.Tabel_Customer.OrderByDescending(a => a.Cust_Id).ToList();
            ViewBag.CustomerList = CustomerList;
            var ProductList = _Context.Table_ProductDetails.ToList();
            ViewBag.ProductList = ProductList;
            return View();
        }
        [HttpGet]
        public JsonResult GetProduct()
        {
            var ProductList = _Context.Table_ProductDetails.ToList();
            ViewBag.ProductList = ProductList;
            return Json(ProductList);

        }
    }
}