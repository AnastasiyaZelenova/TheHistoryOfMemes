namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritanceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memes", "MemeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memes", "MemeType");
        }
    }
}
