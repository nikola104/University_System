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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseReport.xaml
    /// </summary>
    public partial class ExpenseReport : Window
    {

        public List<Person> ExpenseDataSource { get; set; }
        Person currentPerson;

        public ExpenseReport()
        {
            InitializeComponent();
            
            
        }

        public ExpenseReport(object data, List<Person> ExpenseDataSource)
            : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
            this.ExpenseDataSource = ExpenseDataSource;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                string username = usernameBox.Text;
                string password = passwordBox.Password;

                bool flag = false;
            

            foreach (Person p in ExpenseDataSource)
                {
                if (p.Username == username && p.Passowrd == password)
                {
                   currentPerson = p;
                    flag = true;
                    }
                }

                if (flag == true)
                {
                foreach (Expense currExpense in currentPerson.Expenses)
                {
                    if (currExpense.ExpenseAmount == 0)
                        NewButton.Visibility = Visibility.Collapsed;
                    else
                        NewButton.Visibility = Visibility.Visible;


                }
                amountLabel.Visibility = Visibility.Visible;
                    moneyLabel.Visibility = Visibility.Visible;
                    usernameBox.Visibility = Visibility.Collapsed;
                    passwordBox.Visibility = Visibility.Collapsed;
                    loginButton.Visibility = Visibility.Collapsed;
                    usernameLabel.Visibility = Visibility.Collapsed;
                    passwordLabel.Visibility = Visibility.Collapsed;
                
                
                
                }
            else
            {
             MessageBox.Show("Worng Username Or Password");
                usernameBox.Text = "";
                passwordBox.Password = "";

            }






        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
           
            double allAmount = 0;
            foreach(Expense currExpense in currentPerson.Expenses)
            {
                allAmount += currExpense.ExpenseAmount;
            }


            if(allAmount > currentPerson.Amount)
            {
                MessageBox.Show("Sorry But You Don't Have Enough Money In Your Account");
            }

            
            
           else
            {
               

              
            MessageBox.Show("The Transaction Was Successfull");
                this.Close();
               

                currentPerson.Amount = currentPerson.Amount - allAmount;
                foreach (Expense currExpense in currentPerson.Expenses)
                {
                    currExpense.ExpenseAmount = 0;
                    
                    
                }
               

            }


        }
    }
}
