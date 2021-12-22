using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MahalaxmiMarbal.Models
{
    public class Order : Tabel_Customer
    { 
        public int Id { get; set; }
        public Nullable<int> ProductDetailsId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string TotalAmount { get; set; }
        public string TotalDiscount { get; set; }
        public string FinalAmount { get; set; }
        public Nullable<int> OId { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

    }
}