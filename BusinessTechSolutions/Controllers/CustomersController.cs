using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessTechSolutions.DAL;
using BusinessTechSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BusinessTechSolutions.Controllers
{
    public class CustomersController : Controller
    {

        private IBusinessTechSolutionsRepository _businessTechSolutionsRepository;
        public CustomersController()
        {
            _businessTechSolutionsRepository = new BusinessTechSolutionsRepository(new Models.ApplicationDBConnection());
        }
        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            var customer = _businessTechSolutionsRepository.GetAllCustomers();
                
            return View(customer);
        }
    }
}