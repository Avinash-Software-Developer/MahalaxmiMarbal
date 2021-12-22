using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MahalaxmiMarbal.Models;

namespace MahalaxmiMarbal.Controllers
{
    public class SuperAdminController : Controller
    {
        private Mahalaxmi_MarbelsEntities _Context = new Mahalaxmi_MarbelsEntities();
        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }
        //GET: All Vendor Manegment Deatils Code Here
        [HttpGet]
        public ActionResult AllVendorDeatils()
        {
            return View(_Context.Table_Vendor_Registration.ToList());
        }

        //GET: All Bill Mangement 
        [HttpGet]
        public ActionResult AllBillDeatils()
        {
            return View(_Context.Table_Bill.ToList());
        }
    }
}