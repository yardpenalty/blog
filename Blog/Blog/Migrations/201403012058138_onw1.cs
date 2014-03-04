namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vote", "ArticleId", "dbo.Article");
            DropIndex("dbo.Vote", new[] { "ArticleId" });
            AddColumn("dbo.Vote", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Vote", "Article_ArticleId", c => c.Int());
            AddForeignKey("dbo.Vote", "Article_ArticleId", "dbo.Article", "ArticleId");
            CreateIndex("dbo.Vote", "Article_ArticleId");
            DropColumn("dbo.Vote", "ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "ArticleId", c => c.Int(nullable: false));
            DropIndex("dbo.Vote", new[] { "Article_ArticleId" });
            DropForeignKey("dbo.Vote", "Article_ArticleId", "dbo.Article");
            DropColumn("dbo.Vote", "Article_ArticleId");
            DropColumn("dbo.Vote", "Id");
            CreateIndex("dbo.Vote", "ArticleId");
            AddForeignKey("dbo.Vote", "ArticleId", "dbo.Article", "ArticleId");
        }
    }
}
