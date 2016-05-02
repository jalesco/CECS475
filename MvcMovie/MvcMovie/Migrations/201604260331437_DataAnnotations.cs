namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Titles");
            AlterColumn("dbo.Titles", "ISBN", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Titles", "Title", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Titles", "Copyright", c => c.String(maxLength: 4));
            AlterColumn("dbo.Titles", "Subject", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.Titles", "ISBN");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Titles");
            AlterColumn("dbo.Titles", "Subject", c => c.String());
            AlterColumn("dbo.Titles", "Copyright", c => c.String());
            AlterColumn("dbo.Titles", "Title", c => c.String());
            AlterColumn("dbo.Titles", "ISBN", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Titles", "ISBN");
        }
    }
}
