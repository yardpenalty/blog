using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.DAL
{
    public class CatRepository : ICatRepository, IDisposable
    {
        private UsersContext context;

        public CatRepository(UsersContext context)
        {
            this.context = context;
        }

      

        public IEnumerable<Category> GetCats()
        {
  
         return context.Categories.ToList();

        }

        public IQueryable<Category> GetFeaturedCats()
        {
            IList<Category> categories = new List<Category>();
           


            return categories.AsQueryable<Category>();
        }



        public Category GetCategoryById(int catId)
        {
            Category cat = context.Categories.Where<Category>(p => p.CategoryId == catId).FirstOrDefault<Category>();
            return cat;
        }

        public void CreateCat(Category cat)
        {
            context.Categories.Add(cat);
            this.Save();
        }

        public bool CatExists(string title)
        {
            Category cat = context.Categories.Where<Category>(p => p.CategoryName == title).FirstOrDefault<Category>();
            return cat != null;
        }
        public void Category(Category cat)
        {
            context.Entry(cat).State = EntityState.Modified;
            this.Save();
        }

        [Authorize(Roles = "Administrator")]
        public void DeleteCat(Category cat)
        {
            Category deletedCat = context.Categories.Find(cat.CategoryId);
            context.Categories.Remove(deletedCat);
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}