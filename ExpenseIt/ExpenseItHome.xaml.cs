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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {

        public string MainCaptionText { get; set; }

        public List<Person> ExpenseDataSource { get; set; }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public DateTime lastChecked;




        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();




            ExpenseDataSource = new List<Person>()
            {


            new Person()
                {
                    Name="Mike",
                    Department = "Legal",
                    Username="Mike2",
                    Passowrd = "12345",
                    Amount=2000,

                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType = "Lunch", ExpenseAmount= 50},
                       new Expense(){ExpenseType = "Transportation", ExpenseAmount= 50}
                    }
                },
                 new Person()
                {
                    Name="Lisa",
                    Department = "Marketing",
                     Username="Liska",
                    Passowrd = "12345",
                    Amount=2000,
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType = "Document printing", ExpenseAmount= 50},
                       new Expense(){ExpenseType = "Gift", ExpenseAmount= 125}
                    }
                },
                  new Person()
                {
                    Name="John",
                    Department = "Engineering",
                     Username="JohnBaptizer",
                    Passowrd = "12345",
                    Amount=2000,
                    Expenses = new List<Expense>()
                    {
                       new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                       new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                       new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                },
                   new Person()
                {
                    Name="Mary",
                     Username="Mariika",
                    Passowrd = "12345",
                    Amount=20,
                    Department ="Finance",

                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                    new Person()
                {
                    Name="Theo",
                     Username="TeoErnandez",
                    Passowrd = "12345",
                    Amount=2000,
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                        new Person()
                {
                    Name="James",
                     Username="Jam",
                    Passowrd = "12345",
                    Amount=2000,
                    Department ="Driver",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="bus driving", ExpenseAmount=20 }
                    }
                },
                            new Person()
                {
                    Name="David",
                     Username="Davidoso",
                    Passowrd = "12345",
                    Amount=2000,
                    Department ="HR",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="hr-ing", ExpenseAmount=180 }
                    }
                }
            };
            

        }

        public event PropertyChangedEventHandler PropertyChanged;


     
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                // Извикване на PropertyChanged
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = View.Content.ToString();

            foreach (Person currPerson in ExpenseDataSource){
                if (currPerson.Name == name)
                {
                    ExpenseReport expenseReportWindow = new ExpenseReport(currPerson, ExpenseDataSource);
                    expenseReportWindow.Height = 460;
                    expenseReportWindow.Width = 800;
                    expenseReportWindow.ShowDialog();

                }

                }

         
        }

        


        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (peopleListBox.SelectedItem != null && peopleListBox.SelectedItem is Person)
            {
                LastChecked = DateTime.Now;
                PersonsChecked.Add(((Person)peopleListBox.SelectedItem).Name);
            }
        }


    }
}
