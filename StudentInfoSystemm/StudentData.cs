using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginNikola;

namespace StudentInfoSystemm
{
    internal static class StudentData
    {
        public static List<Student> testStudents = new List<Student>();

        static StudentData()
        {
            testStudents.Add(addStudent());

        }

        public static Student addStudent()
        {
           
            Student s1 = new Student();
            
            s1.name = "Gosho";
            s1.surename = "Ivanov";
            s1.familyName = "Ivanov";
            s1.facultet = "FKST";
            s1.major = "KSI";
            s1.educDegree = "Bachelor";
            s1.status = "Active";
            s1.facultetNumber = "42215432";
            s1.course = "3";
            s1.stream = "10";
            s1.group = "43";

         

                return s1;
            
        }

       static Student IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result =
            (from st in context.Students
             where st.facultetNumber == facNum
             select st).First();
            if (result == null)
                return null;
            return result;
        }

    }
}
