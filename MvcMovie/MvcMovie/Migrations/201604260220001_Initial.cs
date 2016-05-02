namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        ISBN = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        EditionNumber = c.Int(nullable: false),
                        Copyright = c.String(),
                    })
                .PrimaryKey(t => t.ISBN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Titles");
        }
    }
}
