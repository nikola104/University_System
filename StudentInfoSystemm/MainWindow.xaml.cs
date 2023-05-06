using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using UserLoginNikola;

namespace StudentInfoSystemm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool flag= false;
        public List<string> StudStatusChoices { get; set; }

    



        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;

                }
            }

            FillStudStatusChoices();

            if (TestStudentsIfEmpty())
                CopyTestStudents();


        

        }

        private void clearAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                   
                }
            }

            foreach (var item in FirstGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }
            }

            foreach (var item in SecondGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }
            }
        }

        private void deactivateFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                    
                }
            }

            foreach (var item in FirstGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;

                }
            }

            foreach (var item in SecondGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;

                }
            }
        }

        private void activateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;

                }
            }
            foreach (var item in FirstGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;

                }
            }
            foreach (var item in SecondGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;

                }
            }

        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();
            

            s1.name = "Ivan";
            s1.surename = "Ivanov";
            s1.familyName = "Ivanov";
            s1.facultet = "FKST";
            s1.major = "KSI";
            s1.educDegree = "Bachelor";
            s1.status = StudStatusChoices[0];
            s1.facultetNumber = "121220175";
            s1.course = "3";
            s1.stream = "10";
            s1.group = "43";

            s2.name = "Nick";
            s2.surename = "Petkov";
            s2.familyName = "Georgiev";
            s2.facultet = "MMSI";
            s2.major = "KSI";
            s2.educDegree = "Bachelor";
            s2.status = "Active";
            s2.facultetNumber = "121220174";
            s2.course = "2";
            s2.stream = "9";
            s2.group = "42";

            s3.name = "Zlatko";
            s3.surename = "Dimitrov";
            s3.familyName = "Ibrahimovic";
            s3.facultet = "M";
            s3.major = "FUT";
            s3.educDegree = "Bachelor";
            s3.status = "Active";
            s3.facultetNumber = "121220173";
            s3.course = "10";
            s3.stream = "7";
            s3.group = "108";

            nameText.Text = s1.name;
            surnameText.Text = s1.surename;
            familyText.Text = s1.familyName;
            facText.Text = s1.facultet;
            specText.Text = s1.major;
            degreeText.Text = s1.educDegree;
            statusComboBox.Text = s1.status;
            facNumText.Text = s1.facultetNumber;
            courseText.Text = s1.course;
            streamText.Text = s1.stream;
            groupText.Text = s1.group;
        }



        void activateAndInputData()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;

                }
            }

            foreach (var item in FirstGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;

                }
            }
            foreach (var item in SecondGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;

                }
            }
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();


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

            s2.name = "Nick";
            s2.surename = "Petkov";
            s2.familyName = "Georgiev";
            s2.facultet = "MMSI";
            s2.major = "KSI";
            s2.educDegree = "Bachelor";
            s2.status = "Active";
            s2.facultetNumber = "121220174";
            s2.course = "2";
            s2.stream = "9";
            s2.group = "42";

            s3.name = "Zlatko";
            s3.surename = "Dimitrov";
            s3.familyName = "Ibrahimovic";
            s3.facultet = "M";
            s3.major = "FUT";
            s3.educDegree = "Bachelor";
            s3.status = "Active";
            s3.facultetNumber = "121220173";
            s3.course = "10";
            s3.stream = "7";
            s3.group = "108";

            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);

            Student stdAnswer = students.OrderBy(s => s.facultetNumber).FirstOrDefault();


            nameText.Text = stdAnswer.name;
            surnameText.Text = stdAnswer.surename;
            familyText.Text = stdAnswer.familyName;
            facText.Text = stdAnswer.facultet;
            specText.Text = stdAnswer.major;
            degreeText.Text = stdAnswer.educDegree;
            statusComboBox.Text = stdAnswer.status;
            facNumText.Text = stdAnswer.facultetNumber;
            courseText.Text = stdAnswer.course;
            streamText.Text = stdAnswer.stream;
            groupText.Text = stdAnswer.group;
        }

        void deleteAndDeactivate()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;

                }
            }
            foreach (var item in FirstGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;

                }
            }
            foreach (var item in SecondGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;

                }
            }

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }
            }
            foreach (var item in FirstGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }
            }
            foreach (var item in SecondGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }
            }



        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties
                .Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";

                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();

                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }

        }

        private void statusComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(string currStr in StudStatusChoices)
            {
            statusComboBox.Items.Add(currStr);

            }


        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
                int countStudents = queryStudents.Count();

            if (countStudents == 0)
            {
                return true;
            }
            return false;
        }


       private void Checking_Click(object sender, RoutedEventArgs e)
        {

            if (TestStudentsIfEmpty())
            {
                MessageBox.Show("true");
            }
            else
                MessageBox.Show("false");



        }

       public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (Student st in StudentData.testStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();

        }





        public void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (User us in UserData.TestUsersList)
            {
                context.Users.Add(us);
            }
                context.SaveChanges();


        }


    }

} 
