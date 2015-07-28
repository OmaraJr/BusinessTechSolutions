using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessTechSolutions.Controllers
{
    public class MembersToViewController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }
    }
}