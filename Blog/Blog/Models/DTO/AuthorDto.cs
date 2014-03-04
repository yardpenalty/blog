using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Models.DTO
{
    public class AuthorDto
    {
        public string UserName { get; set; }
        public int OverallRank { get; set; }
        public virtual List<string> ArticleURIs { get; set; }
        // ranking number then category name
        public virtual IDictionary<int, string> RankingsByCatId { get; set; }
        //category name then point
        public virtual IDictionary<string, int> RepPointsByCat { get; set; }
    }
}