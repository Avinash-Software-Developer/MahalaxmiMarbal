using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MahalaxmiMarbal.Models
{
    public class Product
    {
        public int Product_id { get; set; }

        public string PName { get; set; }

        public int PPrice { get; set; }

        public int PQuantity { get; set; }
    }
}