namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritanceChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Memes", "MemeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memes", "MemeType", c => c.String());
        }
    }
}
