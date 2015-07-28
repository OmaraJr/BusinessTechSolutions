using BusinessTechSolutions.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace BusinessTechSolutions.Controllers
{
    public class HomeController : Controller
    {
        private IBusinessTechSolutionsRepository _businessTechSolutionsRepository;

        public HomeController()
        {
            _businessTechSolutionsRepository = new BusinessTechSolutionsRepository(new Models.ApplicationDBConnection());
        }
       
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var id = User.Identity.GetUserId();
                var user = _businessTechSolutionsRepository.AspNetUser_GetUserById(id);
                if (user.Member == false)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Member");
                }
            }
               
            
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}