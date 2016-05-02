namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Titles", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Titles", "Subject");
        }
    }
}
