using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutorial7ADO.Models
{
    public class CustomerDBModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobileno { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailID { get; set; }
        public List<CustomerDBModel> ShowallCustomer { get; set; }
    }
}