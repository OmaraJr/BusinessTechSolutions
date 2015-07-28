using BusinessTechSolutions.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BusinessTechSolutions.DAL
{
    public class ArticlesRepository : IArticlesRepository
    {
         private ApplicationDBConnection _dbConnection;
        public ArticlesRepository (ApplicationDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Articles> GetAllArticles()
        {
            return _dbConnection.Connection.Query<Articles>("Articles_SelectAllArticles", commandType: CommandType.StoredProcedure);
        }

         
        public bool InsertArticle(Articles article, string userId)
        {
            var a = new DynamicParameters();
            a.Add("UserId", userId);
            a.Add("Title", article.Title);
            a.Add("Description", article.Description);
            a.Add("TagsId", article.TagsId);
            a.Add("ArticleUrl", article.ArticleUrl);
            a.Add("ImageUrl", article.ImageUrl);
            a.Add("Featured", article.Featured);
            a.Add("Likes", article.Likes);
            a.Add("Dislike", article.Dislikes);
            a.Add("IsApproved", article.IsApproved);
            return _dbConnection.Connection.Execute("Articles_InsertArticle", a, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}