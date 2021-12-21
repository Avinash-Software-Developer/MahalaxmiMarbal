using MahalaxmiMarbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahalaxmiMarbal.Controllers
{
    public class VendorController : Controller
    {
        private Mahalaxmi_MarbelsEntities _Context = new Mahalaxmi_MarbelsEntities();
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VendorList()
        {
            var VendorList = _Context.Table_Vendor_Registration.OrderByDescending(a => a.Vendor_id).ToList();
            return View(VendorList);
        }
    }
}