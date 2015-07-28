using BusinessTechSolutions.DAL;
using BusinessTechSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace BusinessTechSolutions.Controllers
{
    public class MemberController : Controller
    {
        private IBusinessTechSolutionsRepository _businessTechSolutionsRepository;
        public MemberController()
        {
            _businessTechSolutionsRepository = new BusinessTechSolutionsRepository(new Models.ApplicationDBConnection());
        }
        // GET: Member
        [Authorize]
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var member = _businessTechSolutionsRepository.BTSMember_GetMemberById(Id);
            return View(member);            
        }

        public ActionResult InsertProfileInformation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertProfileInformation(ProfileInformation profile, string Id)
        {
            var id = User.Identity.GetUserId();
            if(ModelState.IsValid)
            {
                if (_businessTechSolutionsRepository.BTSMember_UpdateProfileInformation(profile, id))
                {
                    return RedirectToAction("Index", "Member");
                }
                return View();
            }
            return View();
        }

       
        
    }
}