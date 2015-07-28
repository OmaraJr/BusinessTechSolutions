using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessTechSolutions.Models
{
    public class Customers
    {
        public IEnumerable<Customers> customers_list { get; set; }
        [Display(Name="ID")]
        public string CustomerId { get; set; }
        [Display(Name="Company Name")]
        public string CustomerName { get; set; }
        [Display(Name="Contact")]
        public string CustomerContactPerson { get; set; }
        [Display(Name="Address")]
        public string CustomerAddress  { get; set; }
        [Display(Name="Email")]
        public string CustomerEmail { get; set; }
        [Display(Name="Phone")]
        public string CustomerPhone { get; set; }
        [Display(Name="Added By")]
        public string InsertedBy { get; set; }
    }
}