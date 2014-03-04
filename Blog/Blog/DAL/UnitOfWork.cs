using BlogSite.DAL;
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.DAL
{
    //instead of using UOW do this ->
    //public class QuestionsController
    //{
    //    private readonly IQuestionRepository _questionRepo;

    //    public QuestionsController(IQuestionRepository questionRepo)
    //    {
    //        _questionRepo = questionRepo;
    //    }

    //    public ActionResult Index(int id, string title)
    //    {
    //        var question = _questionRepo.Get(id);

    //        if (string.IsNullOrWhiteSpace(title) || title != question.Title.ToSlug())
    //        {
    //            return RedirectToAction("Index", new { id, title = question.Title.ToSlug() }).AsMovedPermanently();
    //        }

    //        return View(question);
    //    }
    //}
    public class UnitOfWork : IDisposable
    {
        private UsersContext context = new UsersContext();

       private  ICatRepository catRepository;
        private IArticleRepository articleRepository;
       // private ICatRepository catRepository;
      //private UserRepository userRepository;

        public ICatRepository CategoryRepository
        {
            get
            {

                if (this.catRepository == null)
                {
                    this.catRepository = new CatRepository(context);
                }
                return catRepository;
            }
        }

        public IArticleRepository ArticleRepository
        {
            get
            {

                if (this.articleRepository == null)
                {
                    this.articleRepository = new ArticleRepository(context);
                }
                return articleRepository;
            }
        }

        //public ICatRepository CatRepository
        //{
        //    get
        //    {

        //        if (this.catRepository == null)
        //        {
        //            this.catRepository = new CatRepository(context);
        //        }
        //        return catRepository;
        //    }
        //}
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