using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.DAL
{
    public interface IAdnministratorRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
    }
}
