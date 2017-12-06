namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Memes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Year = c.Int(nullable: false),
                        Image = c.Binary(storeType: "image"),
                        Likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemeGroups",
                c => new
                    {
                        Meme_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meme_Id, t.Group_Id })
                .ForeignKey("dbo.Memes", t => t.Meme_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Meme_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemeGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.MemeGroups", "Meme_Id", "dbo.Memes");
            DropIndex("dbo.MemeGroups", new[] { "Group_Id" });
            DropIndex("dbo.MemeGroups", new[] { "Meme_Id" });
            DropTable("dbo.MemeGroups");
            DropTable("dbo.Memes");
            DropTable("dbo.Groups");
        }
    }
}
