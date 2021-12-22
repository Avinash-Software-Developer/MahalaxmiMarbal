using MahalaxmiMarbal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahalaxmiMarbal.Controllers
{
    public class CustomerController : Controller
    {
        private Mahalaxmi_MarbelsEntities _Context = new Mahalaxmi_MarbelsEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        //GET: All Customer Deatils Code Here
        public ActionResult AllCustomerDeatils()
        {
            return View(_Context.Tabel_Customer.ToList());
        }
        //GET: Add New Customer Design
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        //Post: Add new Customer Code here
        [HttpPost]
        public ActionResult AddCustomer(Tabel_Customer obj)
        {
            try
            {
                _Context.Tabel_Customer.Add(obj);
                _Context.SaveChanges();
                return RedirectToAction("AllCustomerDeatils");
            }
            catch
            {
                return View();
            }

        }


        public ActionResult tempdata()
        {
            BalSuperAdmin objbal = new BalSuperAdmin();
            Tabel_Customer objcust = new Tabel_Customer();
            SqlDataReader dr;
            string CStatus = "Temp";

            dr = objbal.GetlatestCustId(CStatus);
            while (dr.Read())
            {
                string newstdid;

                newstdid = "RTS" + (10000 + dr["StdID"].ToString());

                objcust.Cust_Id = Convert.ToInt32(newstdid);

            }
            //ViewBag.objcust = Cust_Id ;
            return View();
        }


        //Get:Customer/Deatils/Id
        public ActionResult CustomerDetails(int id)
        {
           return View(_Context.Tabel_Customer.Where(x => x.Cust_Id == id).FirstOrDefault());
        }
        //=============All Customer tab Code End Here=================


    }
}