using BusinessTechSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using BusinessTechSolutions.DAL;

namespace BusinessTechSolutions.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticlesRepository _articlesRepository;
        public ArticlesController()
        {
            _articlesRepository = new ArticlesRepository(new Models.ApplicationDBConnection());
        }
    
        // GET: Articles
        public ActionResult Index()
        {
            var articles = _articlesRepository.GetAllArticles();
            return View(articles);
        }
        public ActionResult InsertArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertArticle(Articles article, string userId)
        {
            if(ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                if(_articlesRepository.InsertArticle(article, id))
                {
                    return RedirectToAction("Index", "Articles");
                }

            }
   
            return View();
        }
    }
}