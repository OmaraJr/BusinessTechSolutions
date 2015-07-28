using BusinessTechSolutions.DAL;
using BusinessTechSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;



namespace BusinessTechSolutions.Controllers
{
    public class AdminPageController : Controller
    {
        private IBusinessTechSolutionsRepository _businessTechSolutionsRepository;
        public AdminPageController()
        {
            _businessTechSolutionsRepository = new BusinessTechSolutionsRepository(new Models.ApplicationDBConnection());
        }
        // GET: AdminPage
        public ActionResult Index()
        {
            ViewBag.Customers = _businessTechSolutionsRepository.GetAllCustomers();
            ViewBag.Users = _businessTechSolutionsRepository.Users_GetAllUsers();
            return View();
        }

        public ActionResult Customer_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Customer_Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                //var userId = User.Identity.GetUserId();
                //timeEntry.pay_rate = _timeEntriesRepository.Get_Rate(userId).Pay_Rate;
                if (_businessTechSolutionsRepository.Customer_CreateCustomer(customer))
                {
                    return RedirectToAction("Index", "AdminPage");
                }

            }
            return View();
        }

        public ActionResult Customer_UpdateInformation(int Id)
        {
           // ViewBag.Customers = _businessTechSolutionsRepository.GetAllCustomers();
            var customer = _businessTechSolutionsRepository.Customers_GetCustomerByCustomerId(Id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Customer_UpdateInformation(Customers customer)
        {
            if(ModelState.IsValid)
            {
                if(_businessTechSolutionsRepository.Customer_UpdateInformation(customer))
                {
                    return RedirectToAction("Index", "AdminPage");
                }
            }
                

            return View();
        }
        public ActionResult Customer_Delete(int Id)
        {
            var customer = _businessTechSolutionsRepository.Customers_GetCustomerByCustomerId(Id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Customer_Delete(Customers customer)
        {
            if(ModelState.IsValid)
            {
                if (_businessTechSolutionsRepository.Customer_Delete(customer))
                {
                    return RedirectToAction("Index", "AdminPage");
                }
                   
            }
            return View();
        }

        public ActionResult AspNetUser_Update(string id)
        {
            var user = _businessTechSolutionsRepository.AspNetUser_GetUserById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult AspNetUser_Update(ApplicationUser user, ProfileInformation profile)
        {
            if(ModelState.IsValid)
            {
   
                if(_businessTechSolutionsRepository.AspNetUser_Update(user))
                {
                    var Id = user.Id;
                    _businessTechSolutionsRepository.BTSMember_InsertMemberId(profile, Id);
                    return RedirectToAction("Index", "AdminPage");
                }
            }
            return View();
        }
    }
}