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
        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }
        

       







        //GET: All Vendor Manegment Deatils Code Here
        [HttpGet]
        public ActionResult AllVendorDeatils()
        {
            using (Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities())
            {
                return View(model.Table_Vendor_Registration.ToList());
            }

        }

        //GET: All Bill Mangement 
        [HttpGet]
        public ActionResult AllBillDeatils()
        {
            using (Mahalaxmi_MarbelsEntities model = new Mahalaxmi_MarbelsEntities())
            {
                return View(model.Table_Bill.ToList());
            }
        }

        //public ActionResult test()
        //{
            
        //    return RedirectToAction("tempdata",new RouteValueDictionary(new {Controller="SuperAdmin", Action= "tempdata", Id=2 }));
        //}

    }
}