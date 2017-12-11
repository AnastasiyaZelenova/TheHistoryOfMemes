namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoringImageModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memes", "ImagePath", c => c.String());
            DropColumn("dbo.Memes", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memes", "Image", c => c.Binary());
            DropColumn("dbo.Memes", "ImagePath");
        }
    }
}
