namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vote", "Comment_CommentId", c => c.Int());
            AddForeignKey("dbo.Vote", "Comment_CommentId", "dbo.Comment", "CommentId");
            CreateIndex("dbo.Vote", "Comment_CommentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vote", new[] { "Comment_CommentId" });
            DropForeignKey("dbo.Vote", "Comment_CommentId", "dbo.Comment");
            DropColumn("dbo.Vote", "Comment_CommentId");
        }
    }
}
