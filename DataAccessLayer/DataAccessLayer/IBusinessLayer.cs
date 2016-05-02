using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IBusinessLayer
    {
        //All implemented already
        void addStudent(Student student);
        void deleteStudent(Student student);
        void updateStudent(Student student);
        void printStudentMenu();
        Student searchStudentByID(int id);
        IEnumerable<Student> getAllStudents();

        //For Standard table

      IEnumerable<Standard> getAllStandards();
      Standard GetStandardByID(int id);
      void addStandard(Standard standard);
      void updateStandard(Standard standard);
      void removeStandard(Standard standard);
      Student GetStudentByStandardID(int standardID);


    }//end interface
}//end namespace
