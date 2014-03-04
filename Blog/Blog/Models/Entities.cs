using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BlogSite.Models;

namespace BlogSite.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=BlogSiteConnection")
        {
        }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ranks> Rankings { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Vote> Votes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<PrimaryKeyNameForeignKeyDiscoveryConvention>();
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

           //modelBuilder.Entity<Article>()
           //            .HasRequired(e => e.Category);
           //var article = modelBuilder.Entity<Article>();
           //article.ToTable("Article");

           //article.HasKey(d => new
           //{
           //    d.ArticleId,
           //    d.Title
           //});

           //var questions = modelBuilder.Entity<Question>();
           //questions.ToTable("Question");

           //questions.HasKey(q => new
           //{
           //    q.QuestionId,
           //    q.Title
           //});

           //var answers = modelBuilder.Entity<Answer>();
           //answers.ToTable("Answer");

           //answers.HasKey(a => new
           //{
           //    a.AnswerId,
           //    a.Title
           //});

           //modelBuilder.Entity<Answer>()
           //         .HasRequired(e => e.Question);
           ////            .WithMany(e => e.Answers).WillCascadeOnDelete(true);
           //modelBuilder.Entity<Question>()
           //           .HasOptional(e => e.Answers);
         
                     
         
                      
            //modelBuilder.Entity<TestMaster>()
            //             .HasMany(e => e.Children)
            //             .WithOptional(p => p.Master).WillCascadeOnDelete(false);
          //  modelBuilder.Entity<Article>()
                        //.HasOptional(e => e.Comments)
                        //.WithMany(e => e.Replies)
                        //.HasForeignKey(e => e.MasterId).WillCascadeOnDelete(false);
       
            base.OnModelCreating(modelBuilder);
        }
    }

}