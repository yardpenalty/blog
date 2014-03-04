//using System.Linq;
//using System.Linq.Expressions;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using BlogSite.Models;
//using BlogSite.Models.DTO;

//namespace BlogSite.DAL
//{
//    public class AuthorRepository : IAuthorRepository
//    {
////        private EntityContext context = new EntityContext();

//// Typed lambda expression for Select() method. 
//        private static readonly Expression<Func<UserProfile, AuthorDto>> AsAuthorDto =
//            x => new AuthorDto
//            {
//                UserName = x.Blogger.UserName,
//                Category = x.Category,
//                Content = x.Content,
//                Comments = x.Comments
//            };

//        public IQueryable<Item> GetFeaturedItems()
//        {
//            IList<Item> products = new List<Item>();
            

//            return products.AsQueryable<Item>();
//        }



//        public Item GetItemById(int itemId)
//        {
//            Item item = context.Items.Where<Item>(p => p.ItemId == itemId).FirstOrDefault<Item>();
//            return item;
//        }


//        public IQueryable<Item> GetItemsByCategory(int categoryId)
//        {
//            return context.Items.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Title);
//        }

//        public void CreateItem(Item item)
//        {
//            this.context.Items.Add(item);
//            this.Save();
//        }

//        public bool ItemExists(string title)
//        {
//            Item item = context.Items.Where<Item>(p => p.Title == title).FirstOrDefault<Item>();
//            return item != null;
//        }
//        public void Item(Item item)
//        {
//            context.Entry(item).State = EntityState.Modified;
//            this.Save();
//        }

//        public void DeleteItem(Item item)
//        {
//            Item deletedItem = context.Items.Find(item.ItemId);
//            context.Items.Remove(deletedItem);
//            this.Save();
//        }

//        public void Save()
//        {
//            context.SaveChanges();
//        }

//        private bool disposed = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }
//            this.disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}