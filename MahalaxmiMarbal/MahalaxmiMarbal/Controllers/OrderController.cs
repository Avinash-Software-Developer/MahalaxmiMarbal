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
            var OrderList = _Context.Table_OrderDeatils.OrderByDescending(a=>a.CustomerId).ToList();
            return View(OrderList);
        }
        public ActionResult NewOrder()
        {
            return View();
        }
    }
}