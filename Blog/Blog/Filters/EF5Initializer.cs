//namespace BlogSite.Migrations
//{
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
//                        ImageUrl = "/Content/Avatars/yardpenalty",
//                        DateJoined = DateTime.Now,
//                        UserLevel = 1
//                    },
//                    false);

//            if (!Roles.GetRolesForUser("yardpenalty").Contains("Administrator"))
//                Roles.AddUsersToRoles(new[] { "yardpenalty" }, new[] { "Administrator" });

//            if (!Roles.GetRolesForUser("yardpenalty").Contains("Blogger"))
//                Roles.AddUsersToRoles(new[] { "yardpenalty" }, new[] { "Blogger" });

//            //context.Categories.Add(new Category("ASP.NET MVC4"));
//            //context.Categories.Add(new Category("View Models"));
//            //context.Categories.Add(new Category("Membership Providers"));

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
//            //Tag tag = new Tag();
//            //tag.Name = "MVC";
//            //context.Tags.Add(tag);
//            //Tag tag1 = new Tag();
//            //tag1.Name = "EF";
//            //context.Tags.Add(tag1);
//            //Article article = context.Articles.Find(1);
//            //article.Tags.Add(tag);
//            //article.Tags.Add(tag1);
//            //context.SaveChanges();

//        }


//    }
//}