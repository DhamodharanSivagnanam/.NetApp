using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientMVC.Controllers.Model
{
    public class Product_Details
    {
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public int Supplier_Id { get; set; }
    }
}