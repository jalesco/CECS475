using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//This Titles class will be used to represent the Titles 

namespace MvcMovie.Models
{
    public class Titles
    {
        [Key]
        [StringLength(60), MinLength(4), Required]
        public string ISBN { get; set; }

        [StringLength(120), MinLength(1), Required]
        public string Title { get; set; }

        [Range(1,10)]
        public int EditionNumber { get; set; }

        [StringLength(4)]
        public string Copyright { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

    }//end clas Titles



    public class BookDBContext : DbContext {
        public DbSet<Titles> Titles { get; set; }
    
    }//end class Movie DBContext

    


}//end namespace