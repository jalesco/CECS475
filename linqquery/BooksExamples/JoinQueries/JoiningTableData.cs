// JoiningTableData.cs
// Using LINQ to perform a join and aggregate data across tables.
using System;
using System.Linq;
using System.Windows.Forms;

namespace JoinQueries
{
   public partial class JoiningTableData : Form
   {
      public JoiningTableData()
      {
         InitializeComponent();
      } // end constructor

      private void JoiningTableData_Load( object sender, EventArgs e )
      {
         // Entity Framework DBContext
         BooksExamples.BooksEntities dbcontext =
            new BooksExamples.BooksEntities();

         // get authors and ISBNs of each book they co-authored
         //var authorsAndISBNs =
         //   from author in dbcontext.Authors
         //   from book in author.Titles
         //   orderby author.LastName, author.FirstName
         //   select new { author.FirstName, author.LastName, book.ISBN };

         //outputTextBox.AppendText( "Authors and ISBNs:" );

         //// display authors and ISBNs in tabular format
         //foreach ( var element in authorsAndISBNs )
         //{
         //   outputTextBox.AppendText(
         //      String.Format( "\r\n\t{0,-10} {1,-10} {2,-10}",
         //         element.FirstName, element.LastName, element.ISBN ) );
         //} // end foreach

         // get authors and titles of each book they co-authored (sort by title)
         var authorsAndTitles =
            from book in dbcontext.Titles
            from author in book.Authors
            orderby book.Title1
            select new { author.FirstName, author.LastName,
               book.Title1 };

         outputTextBox.AppendText( "\r\n\r\nAuthors and titles (sorting only by title):" );

         // display authors and titles in tabular format
         foreach ( var element in authorsAndTitles )
         {
            outputTextBox.AppendText(
               String.Format( "\r\n\t{0,-10} {1,-10} {2}",
                  element.FirstName, element.LastName, element.Title1 ) );
         } // end foreach

          //Sort by title, then author last name and first name
         var sortedAuthorsWithTitles =
           from book in dbcontext.Titles
           from author in book.Authors
           orderby book.Title1, author.LastName, author.FirstName
           select new
           {
               author.FirstName,
               author.LastName,
               book.Title1
           };

         outputTextBox.AppendText("\r\n\r\nTitles sorted, then authors by last name and first name:");

         // display authors and titles in tabular format
         foreach (var element in sortedAuthorsWithTitles)
         {
             outputTextBox.AppendText(
                String.Format("\r\n\t{0,-10} {1,-10} {2}",
                   element.FirstName, element.LastName, element.Title1));
         } // end foreach





         // get authors and titles of each book 
         // they co-authored; group by author
         var titlesByAuthor =
            from book in dbcontext.Titles
            orderby book.Title1
            select new { 
               Name = book.Title1,

               Titles =
                  from authors in book.Authors
                  orderby authors.LastName, authors.FirstName //sorted in order from left to right (so sort by last name, then first name)                  
                  select authors.FirstName + " " + authors.LastName
            };

         outputTextBox.AppendText( "\r\n\r\nAuthors grouped by Title, then Sorted by Last Name, then by First Name:" );

         // display titles written by each author, grouped by author
         foreach ( var author in titlesByAuthor )
         {
            // display titles             
            outputTextBox.AppendText( "\r\n\t" + author.Name + ":" );

            // display authors who wrote that book
            foreach ( var title in author.Titles )
            {
               outputTextBox.AppendText( "\r\n\t\t" + title );
            } // end inner foreach
         } // end outer foreach
      } // end method JoiningTableData_Load
   } // end class JoiningTableData
} // end namespace JoinQueries

