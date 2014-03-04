using BlogSite.Models;
using BlogSite.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.DAL
{
    //role provider interfacing...read http://martinfowler.com/bliki/InterfaceImplementationPair.html for
    // more about role versus header interfacing
    public interface ICatRepository 
    {
         IEnumerable<Category> GetCats();
        IQueryable<Category> GetFeaturedCats();
        Category GetCategoryById(int catId);
        void CreateCat(Category cat);
        bool CatExists(string title);
        void DeleteCat(Category cat);
    }
}