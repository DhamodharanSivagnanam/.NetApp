using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientMVC.Controllers.Model
{
    public class Supplier_Info
    {
        public int Supplier_Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
    }
}