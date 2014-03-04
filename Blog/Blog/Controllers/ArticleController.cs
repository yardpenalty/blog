using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSite.Models;
using WebMatrix.WebData;
using BlogSite.DAL;
using System.IO;
using System.Text;
using BlogSite.Helpers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.Security;
using BlogSite.ViewModels;


namespace BlogSite.Controllers
{
    
    public class ArticleController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        
        // 
        // GET: /Article/

        public ActionResult Index()
        {
           
          
            _unitOfWork.ArticleRepository.SubmitVote(1,1,true);

            if (WebSecurity.IsAuthenticated)
                return View(_unitOfWork.ArticleRepository.GetFeaturedArticles());

            return RedirectToAction("Index", new { username = WebSecurity.CurrentUserName });
        }


        //
        //// GET: /Article/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetCats(), "CategoryId", "CategoryName");

            return View();
        }

        ////
        //// POST: /Article/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            article.UserId = WebSecurity.CurrentUserId;
            if (ModelState.IsValid)
            {
                _unitOfWork.ArticleRepository.CreateArticle(article);
                return RedirectToAction("Details", new { id = article.ArticleId });
            }

            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetCats(), "CategoryId", "CategoryName");
            return View(article);
        }

        //
        // GET: /Article/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Article article = _unitOfWork.ArticleRepository.GetArticleById(id);
            if (article.Blogger.UserId == WebSecurity.CurrentUserId)
            {
                if (article == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetCats(), "CategoryId", "CategoryName");
               
                return View(article);
               
            }

            return View();
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
                if (ModelState.IsValid)
                {

                    
                        _unitOfWork.ArticleRepository.UpdateArticle(article);
                        return RedirectToAction("Details", new { id = article.ArticleId });
                    
               
                }
            
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetCats(), "CategoryId", "CategoryName", article.CategoryId);
            return View(article);
        }

        #region testing details w/UrlEncoder.URLFriendly(url)
        ///<summary>
        ///Works fine with 
        ///routes.MapRoute(name: "Article", url: "Article/{id}/{title}/",defaults: new { controller = "Article", action = "Details", id = "", title = "" });
        /// but need it to redirect when missing title and date
        /// </summary
        //
        // GET: /Article/Details/5
        public ActionResult Details(int id, string title)
        {
            ViewBag.Count = _unitOfWork.ArticleRepository.GetCommentCount(id);
            var article = _unitOfWork.ArticleRepository.GetArticleById(id);
            ViewBag.Type = GetObjectType(article); // article.GetType().Name.ToString();
           // TempData["count"] = Membership.GetNumberOfUsersOnline().ToString();
            ViewBag.UserLevel = GetUserLevel(article);

            if (string.IsNullOrWhiteSpace(title) || title != article.Title.ToSlug())
            {
                return RedirectToAction("Details", new { id = article.ArticleId, title = article.Title.ToSlug()}).AsMovedPermanently();
            }
            if (article == null && title == null)
            {
                return HttpNotFound();
            }
  
            return View(article);
        }
        #endregion

        #region Comment Stuff Child Actions
        [ChildActionOnly]
        public ActionResult GetCommentsById(int AId = 0)
        {
          
            if (AId == 0)
                return HttpNotFound();

            return PartialView("_CommentsPartial", _unitOfWork.ArticleRepository.GetCommentsByArticleId(AId));
        }

        public string GetContentById(int CId)
        {
            string content = _unitOfWork.ArticleRepository.GetCommentContent(CId);

            return content;
        }

         [HttpPost]
        public ActionResult SaveEditByCommentId(int CId, string content) { 
              Comment comment = _unitOfWork.ArticleRepository.GetCommentById(CId);

              if (WebSecurity.CurrentUserId.Equals(comment.UserId))
              {
                  _unitOfWork.ArticleRepository.UpdateComment(comment, content);

                  return Content(comment.Content);
              }

              return PartialView();
        }

         public int GetCommentCountByAId(int AId)
         {
             return _unitOfWork.ArticleRepository.GetCommentCount(AId);
         }


        public ActionResult DelCom(int AId, int CId)
        {

            if (WebSecurity.IsCurrentUser(User.Identity.Name))
            {
                _unitOfWork.ArticleRepository.DeleteComment(AId, CId);

                return PartialView("_CommentsPartial", _unitOfWork.ArticleRepository.GetCommentsByArticleId(AId));
            }
            else
                return PartialView();
        }

        public int GetCommentCount(int id)
        {
            return _unitOfWork.ArticleRepository.GetCommentCount(id);
        }

        //
        //GET: creates view model only
       
        [HttpGet]
        public ActionResult AddComment(int AId, int PId = 0)
        {

            Comment comment = new Comment(AId, WebSecurity.CurrentUserId);
            if (WebSecurity.CurrentUserId.Equals(comment.UserId))
            {
                if (PId == 0)
                {
                    return PartialView("_AddPostPartial", comment);     
                }
                else
                {
                    comment.ParentCommentId = PId;
                    return PartialView("_AddReplyPartial", comment);
                }
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult Post(Comment comment)
        {

            if (ModelState.IsValid)
            {
                ViewBag.ReturnUrl = comment.ArticleId;
                _unitOfWork.ArticleRepository.InsertComment(comment);
                return PartialView("_CommentsPartial", _unitOfWork.ArticleRepository.GetCommentsByArticleId(comment.ArticleId));
            }

            return PartialView("_AddPostPartial", comment);
        }

        public ActionResult CommentChanged(string content, int CId, int TId)
        {
            
           Comment comment = _unitOfWork.ArticleRepository.GetCommentById(CId);
           if (WebSecurity.CurrentUserId.Equals(comment.UserId))
           {
               _unitOfWork.ArticleRepository.UpdateComment(comment,content);
               return PartialView("_CommentsPartial", _unitOfWork.ArticleRepository.GetCommentsByArticleId(comment.ArticleId));
           }
           return PartialView();
          
        }

        public ActionResult GetJSONCommentCount(int AId)
        {
            return Json(
                new { Count = _unitOfWork.ArticleRepository.GetCommentCount(AId) }
                );
        }
        #endregion

        #region Tags

        public ActionResult SearchArticlesByTagId(int TId)
        {
           // http://stackoverflow.com/questions/20917251/linq-selectmany-with-null-child
            var result = _unitOfWork.ArticleRepository.FindArticlesByTagId(TId);
         //   var name = _unitOfWork.TagRepository.FindTagById(TId);
            var e = result.Select(x => new TitleViewModel{
              //  TagName = name.TagName,
                ArticleId = x.ArticleId,
                Title = x.Title,
                CategoryName = x.Category.CategoryName,
                AuthorName = x.Blogger.UserName,
                PartialContent = x.Content
                ////foreach() => x.Tags
        //        ////                 TagNames = x.TagNames
        //         var vs = result.SelectMany(x => x.AccessRules, (a, b) => new MenuDetailsViewModel
        //{
        //    MenuId = a.MenuId,
        //    DisplayText = a.DisplayText,
        //    MenuOrder = a.MenuOrder,
        //    HasKids = a.HasKids,
        //    MenuStatus = a.MenuStatus,
        //    AccessRuleLists = a.AccessRules.
        //        Select(c => new AccessRulesList { 
        //            Id = b.Id, 
        //            MenuId = b.Menu.MenuId, 
        //            RoleId = b.Roles.RoleId,
        //            CanCreate = b.CanCreate, 
        //            CanUpdate = b.CanUpdate, 
        //            CanDelete = b.CanDelete }).ToList()
        //}).SingleOrDefault();
            }).ToList();
        
            return View("SearchedArticles", e);
        }
        #endregion

        #region Reputation
        public void AddPoints(int AId, PointValues value)
        {
            _unitOfWork.ArticleRepository.AddRepPoints(AId, value);
        }
        #endregion

        [ChildActionOnly]
        public ActionResult GetUserArticles(string username = "")
        {
            if (username == "")
                return HttpNotFound();

            return View(_unitOfWork.ArticleRepository.GetArticlesByUsername(username));
        }
       
        public JsonResult UploadPicture()
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/themes/imgs")
                    , Path.GetFileName(file.FileName));
                    file.SaveAs(filePath);
                    var path = Url.Content(Path.Combine("/Content/themes/imgs", file.FileName));// this the difference
                    return Json(path);
                }
            }
            return Json("failed !");
        }

      

        ////
        //// GET: /Article/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Article article = db.Articles.Find(id);
        //    if (article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(article);
        //}

        ////
        //// POST: /Article/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Article article = db.Articles.Find(id);
        //    db.Articles.Remove(article);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet, ActionName("Category")]
        [ChildActionOnly]
        public ActionResult AddCategory()
        {

            Category cat = new Category();

            return PartialView("_AddCategoryPartial", cat);
        }

        [ChildActionOnly, HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category cat)
        {
            var category = _unitOfWork.CategoryRepository.GetCategoryById(cat.CategoryId);
            if (!ModelState.IsValid || category == null)
            {
                return PartialView(cat);
            }

            return RedirectToAction("Create");
        }

        public int GetUserLevel(Article article)
        {
            var authors = _unitOfWork.ArticleRepository.GetUsersArticlesById(article.UserId);
           
            return authors.Count();
        }

        public static string GetObjectType<Entity>(Entity e) { 
        return typeof(Entity).Name; 
    }
       
    }
}