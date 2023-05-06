using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace UserLoginNikola
{
    class Program
    {


        
        public delegate void ActionOnError(string errorMsg);
        

        public static void errorFunc(string errorString)
        {

            Console.WriteLine("!!! " + errorString + " !!!");
             
        }

        static void Main(string[] args)
        {
            User u1 = null;



            String password;
           String username;
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();




            ActionOnError aon = new ActionOnError(errorFunc);

            LoginValidation lv = new LoginValidation(username, password, errorFunc);


            if (lv.ValidateUserInput(ref u1))
            {

                u1.toString();

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        adminMenu();
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("STUDENT -> You are regular student");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("No existed a person");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("PROFESSOR -> You are teaching the students");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("INSPECTOR -> You are inspectiong the students");
                        break;
                }



                Console.ReadLine();
            }
        }
      
        public static void adminMenu()
        {
                int option;
            do
            {
                
                Console.Write("Choose an option: " +
                    "\n0: exit" +
                    "\n1: Change the role of the user" +
                    "\n2: Change the expiry date of user" +
                    "\n3: List of all users" +
                    "\n4: Show Log activity" +
                    "\n5: Show current activity" +
                    "\nYour choice ->: ");

                option = Convert.ToInt32(Console.ReadLine());
                                             
                  Int32 UserId;

                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        int role;
                        Console.Write("USER ID : ");
                        UserId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Role Number: ");
                        role = Convert.ToInt32(Console.ReadLine());

                        UserData.AssignUserRole(UserId, (UserRoles)role);
                        option = 15;
                        break;
                    case 2:

                        //DateTime expiryDate;

                        Console.Write("USER ID : ");
                        UserId = Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine("Role Number: ");
                        //expiryDate = Convert.ToDateTime(Console.ReadLine());


                        UserData.SetUserActiveTo(UserId, DateTime.Now);

                        break;
                    case 3:

                        Console.WriteLine("List of all users : ");
                        break;
                    case 4:
                        //writing files
                        writeLogFile();
                        //reading files
                        readLogFile();
                       
                        break;
                    case 5:
                        StringBuilder sb = new StringBuilder();
                        string filter;
                        Console.Write("Search by words: ");
                        filter = Console.ReadLine();
                        IEnumerable<string> currSessionAct = Logger.GetCurrentSessionActivities(filter);
                        foreach (String curStr in currSessionAct)
                        {
                            sb.Append("* " + curStr + "\n");
                        }

                        Console.WriteLine(sb.ToString());
                        
                        
                        break;

                    default: 
                        Console.WriteLine("Input a real Value");
                        break;
                }
                

                 

            } while (!(option == 1 || option == 2 || option == 3 || option == 4 || option == 5));


          

        }


        public static void writeLogFile()
        {
                StringBuilder sb = new StringBuilder();

            if (File.Exists("test.txt"))
            {
                foreach(string currStr in Logger.currentSessionActivities)
                {
                    sb.Append(currStr+"\n");
                }
                File.AppendAllText("test.txt",sb.ToString() + "\n");
            }

            

        }
        public static void readLogFile()
        {
            if (File.Exists("test.txt"))
            {
                string buffer;
                buffer = File.ReadAllText("test.txt");
                Console.WriteLine(buffer);
            }
        }

    }
}
