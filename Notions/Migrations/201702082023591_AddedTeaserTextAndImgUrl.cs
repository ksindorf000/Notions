namespace Notions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeaserTextAndImgUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "TeaserText", c => c.String());
            AddColumn("dbo.BlogPosts", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPosts", "ImgUrl");
            DropColumn("dbo.BlogPosts", "TeaserText");
        }
    }
}
