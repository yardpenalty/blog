using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Models.DTO
{
    public class ArticleDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}