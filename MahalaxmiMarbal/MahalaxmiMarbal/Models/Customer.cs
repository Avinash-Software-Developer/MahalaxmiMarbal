using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MahalaxmiMarbal.Models
{
    public class Customer
    {
        public int Cust_Id { get; set; }
        
        public string CustName { get; set; }

        public string CustPh { get; set; }

        public string CustAddress { get; set; }

        public string CustEmail { get; set; }

        public string Date { get; set; }
    }
}