using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
     class StudentData
    {
       public List<Student> TestStudents { get;private set; }

        
        public void addStudent()
        {
            Student s1 = new Student();
            s1.name = "Ivan";
            s1.surename = "Ivanov";
            s1.familyName = "Ivanov";
            s1.facultet = "FKST";
            s1.major = "KSI";
            s1.educDegree = "Bachelor";
            s1.status = "Active";
            s1.facultetNumber = "121220175";
            s1.course = "3";
            s1.stream = "10";
            s1.group = "43";
            TestStudents.Add(s1);
        }

    }
}
