namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vote", "Liked", c => c.Boolean(nullable: false));
            DropColumn("dbo.Vote", "LikedArticle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "LikedArticle", c => c.Boolean(nullable: false));
            DropColumn("dbo.Vote", "Liked");
        }
    }
}
