using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BusinessLayer : IBusinessLayer
    {

        private readonly IStandardRepository _IStandardRepository;
        private readonly IStudentRepository _IStudentRepository;
        public BusinessLayer() {
            _IStandardRepository = new StandardRepository();
            _IStudentRepository = new StudentRepository();
        }

        //Prints the overall menu for the program. Each menu for standard and student are implemented separately and called here

        public void printOverallMenu() {
            int menu = 0;
            bool loop = true;
            BusinessLayer businessLayer = new BusinessLayer();
            do
            {               
                Console.WriteLine("1. Student Menu" + "\n" + "2. Standard Menu" + "\n" + "3. Quit");
                menu = Int32.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        businessLayer.printStudentMenu();
                        break;
                    case 2:
                        businessLayer.printStandardMenu();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using the program.");
                        loop = false;
                        break;
                }//end switch statement            
            } while (loop);

        }//end printOverallMenu

        //Student specific functions
        //Finished: Insert, Delete
        //Need: Update, Search for one, list all
        public void addStudent(Student student) {
            int standardID = 0;
            string name = null;
            student = new Student();
           
            Console.WriteLine("Enter the name of the student: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter standard ID: ");
            standardID = Int32.Parse(Console.ReadLine());

            student.StudentName = name;
            student.StandardId = standardID;
            student.RowVersion = null;
            _IStudentRepository.Insert(student);
        }//end addStudent

        public void deleteStudent(Student student) {            
            string name = null;
            Console.WriteLine("Enter name of student to delete: ");
            name = Console.ReadLine();
            using (var ctx = new SchoolDBEntities()) {
                student = ctx.Students.Where(s => s.StudentName == name).FirstOrDefault<Student>();
            }
            if (student == null) {
                Console.WriteLine("Record doesn't exist.");
            }
            _IStudentRepository.Delete(student);
        }//end deleteStudent

        public void updateStudent(Student student) {
            string name = null, updateName = null;
            Console.WriteLine("Enter the name of the student you want to update: ");
            name = Console.ReadLine();           
            //Find the student the user wants to modify by the name
            using (var ctx = new SchoolDBEntities()) {
                student = ctx.Students.Where(s => s.StudentName == name).FirstOrDefault<Student>();                
            }
            if (student == null)
            {
                Console.WriteLine("Record doesn't exist. Closing the program...(temp)");
                Environment.Exit(0); //temporarily close the program
            }
            //Display student that the user wants to change
            Console.WriteLine("Student ID: " + student.StudentID + "\n" + "Student Name: " + student.StudentName +
                "\n" + student.StandardId);
          
            //Ask user to enter new name
                Console.WriteLine("Enter new name for student: ");
                updateName = Console.ReadLine();
                student.StudentName = updateName;
                
                //_IStudentRepository.Update(student);            
            
        }//end updateStudent

        public Student searchStudentByID(int id)
        {
            return _IStudentRepository.GetByID(id);                                                            
        }


        public IEnumerable<Student> getAllStudents()
        {
            return _IStudentRepository.GetAll();            
        }


        public void printStudentMenu() {
            int menu = 0;
            bool loop = true;
            var student = new Student();
            BusinessLayer businessLayer = new BusinessLayer();

                
                Console.WriteLine("1. Insert Student\n2. Delete Student\n3. Update Student name\n4. Display Students\n5. Search for Student by ID"
                    + "\n" + "6. Main Menu");
                menu = Int32.Parse(Console.ReadLine());
                switch (menu)
                {
                    //Insert Student (works)
                    case 1:
                        businessLayer.addStudent(student);
                        break;
                    //Delete Student (works)
                    case 2:
                        businessLayer.deleteStudent(student);
                        break;
                    //Update Student (works)
                    case 3:
                        businessLayer.updateStudent(student);
                        break;
                    //Display all Students (works)
                    case 4:
                        IEnumerable<Student> list = businessLayer.getAllStudents();
                        foreach (Student s in list)
                        {
                            Console.WriteLine("\nStudent name: " + s.StudentName + "\nStudent ID: " + s.StudentID + "\nStandard ID: " + s.StandardId);
                        }
                        break;
                    //
                    case 5:
                        int id = 0;
                        Console.WriteLine("Enter student id: ");
                        id = Int32.Parse(Console.ReadLine());
                        student = businessLayer.searchStudentByID(id);
                        Console.WriteLine("Student name: " + student.StudentName + "\nStudent ID: " + student.StudentID + "\nStandard ID: " + student.StandardId);
                        break;
                    case 6:
                        loop = false;
                        break;
                }//end switch       
        }//end printStudentMenu


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //For Standard objects
        public void printStandardMenu()
        {
            int menu = 0;
            bool loop = true;
            var standard = new Standard();
            BusinessLayer businessLayer = new BusinessLayer();


                Console.WriteLine("1. Insert Standard\n2. Delete Standard\n3. Update Standard name\n4. Display Standards\n5. Search for Standard by ID"
                    + "\n" + "6. Get Single" + "\n" + "7. Search Standard by Name" + "\n" + "8. Main Menu");
                menu = Int32.Parse(Console.ReadLine());
                switch (menu)
                {
                    //Insert Student (works)
                    case 1:
                        businessLayer.addStandard(standard);
                        break;
                    //Delete Student (works)
                    case 2:
                        businessLayer.removeStandard(standard);
                        break;
                    //Update Student (works)
                    case 3:
                        businessLayer.updateStandard(standard);
                        break;
                    //Display all Students (works)
                    case 4:
                        IEnumerable<Standard> list = businessLayer.getAllStandards();
                        foreach (Standard s in list)
                        {
                            Console.WriteLine("\nStandard name: " + s.StandardName + "\nStandard ID: " + s.StandardId);
                        }
                        break;
                    
                    case 5:
                        int id = 0;
                        Console.WriteLine("Enter standard ID: ");
                        id = Int32.Parse(Console.ReadLine());
                        standard = businessLayer.GetStandardByID(id);
                        Console.WriteLine("Standard name: " + standard.StandardName + "\nStandard ID: " + standard.StandardId);
                        break;
                    
                     //Using GetSingle function
                    case 6:                        
                        Console.WriteLine("Enter StandardID:");
                        id = Int32.Parse(Console.ReadLine());
                        Student checkingStudent = businessLayer.GetStudentByStandardID(id);
                       if(checkingStudent != null)
                       {
                           Console.WriteLine("StudentID: "+checkingStudent.StudentID+"\nStudentName:"+checkingStudent.StudentName);
                       }
                       else
                       {
                           Console.WriteLine("was not found");
                       }
                        break;
                    case 7:
                        string name = null;
                        Console.WriteLine("Enter standard name: ");
                        name = Console.ReadLine();
                        standard = businessLayer.SearchStandardByName(name);
                        Console.WriteLine("Standard ID: " + standard.StandardId + "\n" + "Standard Name: " + standard.StandardName);
                        break;
                    case 8:
                        loop = false;
                        break;
                }//end switch
        }//end printStudentMenu


        public void addStandard(Standard standard)
        {
            string standardName = null, description = null;
            standard = new Standard(); 
            Console.WriteLine("Enter the name of the standard: ");
            standardName = Console.ReadLine();
            Console.WriteLine("Enter the description: ");
            description = Console.ReadLine();

          
            standard.StandardName = standardName;
            standard.Description = description;          
            _IStandardRepository.Insert(standard);
        }//end addStudent

        public void removeStandard(Standard standard) {
            string name = null;
            standard = new Standard();
            Console.WriteLine("Enter name of standard to delete: ");
            name = Console.ReadLine();
            //Retrieve the object they want to delete
            using (var ctx = new SchoolDBEntities())
            {
                standard = ctx.Standards.Where(s => s.StandardName == name).FirstOrDefault<Standard>();
            }
            while (standard == null)
            {
                Console.WriteLine("Record doesn't exist. Re-enter: ");
                name = Console.ReadLine();
            }
            _IStandardRepository.Delete(standard);
        }//end deleteStandard

        public void updateStandard(Standard standard)
        {
            string name = null;
            Console.WriteLine("Enter the name of the standard you want to update: ");
            name = Console.ReadLine();
            //Find the student the user wants to modify by the name
            using (var ctx = new SchoolDBEntities())
            {
                standard = ctx.Standards.Where(s => s.StandardName == name).FirstOrDefault<Standard>();
            }
            if (standard == null)
            {
                Console.WriteLine("Record doesn't exist. Closing the program...(temp)");
                Environment.Exit(0); //temporarily close the program
            }
            //Display the student wants to update the student
            Console.WriteLine("Student ID: " + standard.StandardId + "\n" + "Standard Name: " + standard.StandardName +
                "\n" + "Description: " + standard.Description);

            Console.WriteLine("Enter new name for standard: ");
            string updatedName = Console.ReadLine();
            standard.StandardName = updatedName;
            _IStandardRepository.Update(standard);
        }//end updateStandard

        public Standard GetStandardByID(int id)
        {
            return _IStandardRepository.GetByID(id);
        }

        public Standard SearchStandardByName(string name)
        {
            Standard standard = new Standard();
            using (var ctx = new SchoolDBEntities())
            {
                standard = ctx.Standards.Where(s => s.StandardName == name).FirstOrDefault<Standard>();
            }
            return standard;
        }//end SearchStandardByName
        

        public IEnumerable<Standard> getAllStandards() {
            return _IStandardRepository.GetAll();
        }//end getAllStandards


        //This is the method that will get both 
        public Student GetStudentByStandardID(int standardID)
        {
            var studentIdentity = _IStudentRepository.GetSingle(q => q.StandardId == standardID);
            Student Student = new Student();
            if (studentIdentity != null)
            {
                Student = _IStudentRepository.GetSingle(o => o.StandardId == studentIdentity.StandardId);
            }
            else
            {
                Student = null;
            }

            return Student;
        }//end of GetStudentByStandardID


    }// end BusinessLayer
}// end namespace
