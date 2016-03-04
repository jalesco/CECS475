using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<Student> rep = new Repository<Student>(new SchoolDBEntities());

            Student s = new Student();
            s.StudentID = 13;
            s.StudentName = "Jon O.";
            s.StandardId = 13;
            s.RowVersion = null;

            rep.Insert(s);

            

        }// end main
    }// end class
}// end namespace
