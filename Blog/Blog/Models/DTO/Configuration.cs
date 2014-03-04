//namespace BlogSite.Migrations
//{
//    using BlogSite.DAL;
//    using BlogSite.Models;
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;
//    using System.Web.Security;
//    using WebMatrix.WebData;

//    internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = true;
//        }

//        protected override void Seed(UsersContext context)
//        {
//            CatRepository _catsRepo = new CatRepository(context);
//            UnitOfWork initWork = new UnitOfWork();

//            WebSecurity.InitializeDatabaseConnection(
//                "BlogSiteConnection",
//                "UserProfile",
//                "UserId",
//                "UserName", autoCreateTables: true);

//            if (!Roles.RoleExists("Administrator"))
//                Roles.CreateRole("Administrator");
//            if (!Roles.RoleExists("Blogger"))
//                Roles.CreateRole("Blogger");

//            if (!WebSecurity.UserExists("yardpenalty"))
//                WebSecurity.CreateUserAndAccount(
//                    "yardpenalty",
//                    "victor23",
//                    new
//                    {
//                        Email = "yardpenalty@yahoo.com",
//                        ImageUrl = "/Content/Avatars/yardpenalty.jpg",
//                        DateJoined = DateTime.Now,
//                        UserLevel = 1
//                    },
//                    false);

//            if (!Roles.GetRolesForUser("yardpenalty").Contains("Administrator"))
//                Roles.AddUsersToRoles(new[] { "yardpenalty" }, new[] { "Administrator" });

//            if (!Roles.GetRolesForUser("yardpenalty").Contains("Blogger"))
//                Roles.AddUsersToRoles(new[] { "yardpenalty" }, new[] { "Blogger" });

//            if (!_catsRepo.CatExists("ASP.NET MVC4"))
//                context.Categories.Add(new Category("ASP.NET MVC4"));
//            if (!_catsRepo.CatExists("View Models"))
//                context.Categories.Add(new Category("View Models"));
//            if (!_catsRepo.CatExists("Membership Providers"))
//                context.Categories.Add(new Category("Membership Providers"));
//            if (!_catsRepo.CatExists("Ajax"))
//                context.Categories.Add(new Category("Ajax"));
//            if (!_catsRepo.CatExists("Razor View Engine"))
//                context.Categories.Add(new Category("Razor View Engine"));

//            //Article entity = new Article();
//            //entity.CategoryId = 1;
//            //entity.UserId = 1;
//            //entity.Title = "Testing the Commenting section";
//            //entity.Content = "There is no html in this article. This is just a test to see if we can get our comments that belong to an article to show up. The format may be ugly but as long as we get a comment we can delete this article from the database.<br /> (___((___________()~~~~~~~~";

//            //context.Articles.Add(entity);
//            //context.SaveChanges();
//            //Comment comment = new Comment(4, 1);
//            //comment.Content = "This is the very first comment ever on this site";
//            //context.Comments.Add(comment);
//            context.SaveChanges();
//            initWork.ArticleRepository.AddRepPoints(1, PointValues.Share);
//            initWork.ArticleRepository.AddTagByIds(1, 1);
//            initWork.ArticleRepository.AddTagByIds(1, 2);
//            initWork.ArticleRepository.AddTagByIds(1, 3);

//        }


//    }
//}