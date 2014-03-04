using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.ViewModels
{
    public class TitleViewModel
    {
        public int ArticleId {get; set; }
        public string Title { get; set; }
        public String PartialContent { get; set; }
        public String AuthorName { get; set; }
        public String CategoryName { get; set; }
        public virtual IList<String> TagNames {get;set;}
        public virtual ICollection<Vote> Votes { get; set; }
//        var title = from p in context.Articles.Include(t => t.ArticleId, t => t.Title)
//let spanishOrders = p.OrderDetails.Where (o => o.Order.ShipCountry == "Spain")
//where spanishOrders.Any()
//orderby p.ProductName
//select new
//{
//    p.ProductName,
//    p.Category.CategoryName,
//    Orders = spanishOrders.Count(),	
//    TotalValue = spanishOrders.Sum (o => o.UnitPrice * o.Quantity)
//}
    }
}