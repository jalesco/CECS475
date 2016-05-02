namespace MvcMovie.Migrations
{
    using MvcMovie.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.BookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMovie.Models.BookDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Titles.AddOrUpdate(
            //  p => p.ISBN,
            //  new Titles { 
            //      ISBN = "2233",
            //      Title = "Swift and Apple",
            //      EditionNumber = 3,
            //      Copyright = "2013",
            //      Subject = "Computer Science"
              
            //  }
           // );
            
        }//end seed
    }//end class
}//end namespace
