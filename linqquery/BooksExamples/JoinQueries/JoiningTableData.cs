// JoiningTableData.cs
// Using LINQ to perform a join and aggregate data across tables.
//LAB 4: LINQ Queries

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

         var allISBN = from book in dbcontext.Titles
                       orderby book.Title1
                       select new
                       {
                           book.ISBN,
                           book.Title1
                       };

         foreach (var element in allISBN) {
             outputTextBox.AppendText(element.ISBN + ", " + element.Title1 + "\n");
         }

          //1) Gets the titles of the books and the authors that wrote them. LINQ Query with multiple tables
         var authorsAndTitles =
            from book in dbcontext.Titles //accesses the Titles table in the database
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

          //2) Sort by title, then author last name and first name
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

         // 3) get authors and titles of each book they co-authored; group by author

          /*
           Steps: 
           * 1) Create a new object to hold LINQ object
           * 2) Retrieve the data from the Titles table from the database
           */
         var titlesByAuthor =
            from book in dbcontext.Titles
            orderby book.Title1

            select new { 
               Name = book.Title1,

               Titles =
                  from authors in book.Authors
                  orderby authors.LastName, authors.FirstName                 
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

