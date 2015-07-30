using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessTechSolutions.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public string  UserId { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        public int TagsId { get; set; }
        public string  ArticleUrl { get; set; }
        public string ImageUrl { get; set; }
        public bool Featured { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool IsApproved { get; set; }
        public bool NargesIsCool { get; set; }
    }
}