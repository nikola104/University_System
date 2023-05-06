using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNikola
{
     public static class UserData
    {
        
    
        private static List<User> testUsersList;

        static private void ResetTestUserData()
        {
            if(testUsersList == null)
            {
                testUsersList = new List<User>();   


                User u1 = new User();
                u1.username = "Ivancho";
                u1.password = "12345";
                u1.fakNomer = 121220;
                u1.role = UserRoles.ADMIN;
                u1.created = DateTime.Now;
                u1.expiryDate = DateTime.MaxValue;

                testUsersList.Add(u1);




                User u2 = new User();

                u2.username = "Mariika";
                u2.password = "12345";
                u2.fakNomer = 1212457;
                u2.role = UserRoles.STUDENT;
                u2.created = DateTime.Now;
                u2.expiryDate = DateTime.MaxValue;

                testUsersList.Add(u2);




                User u3 = new User();

                u3.username = "Gosho";
                u3.password = "12345";
                u3.fakNomer = 42215432;
                u3.role = UserRoles.STUDENT;
                u3.created = DateTime.Now;
                u3.expiryDate = DateTime.MaxValue;

                testUsersList.Add(u3);


            }

        }

        public static List<User> TestUsersList
        {
            get { ResetTestUserData(); return testUsersList;}
            set { }
        }

        

        public static User isUserPassCorrect(string username,string pass)
        {
            UserContext context = new UserContext();

            List<User> testUsers = (from user in context.Users
                                    where
                                     user.username == username && user.password == pass
                                     select user).ToList();

            if(testUsers.Count() == 0)
            {
            return null;
            }
                return testUsers.First();

           
        }

        public static void SetUserActiveTo(Int32 userId, DateTime expiryDate)
        {
            // old way
            /*foreach(User user in TestUsersList)
            {
                if(user.username == username)
                {
                    user.expiryDate = expiryDate;
                    Logger.LogActivity("The expiry time to: " + user.username + " has been changed!");
                }
            }*/
            UserContext context = new UserContext();

            User user = (from u in context.Users
                         where u.UserId == userId
                         select u).First();
            user.expiryDate = expiryDate;
            Logger.LogActivity("The expiry time to user with id: " + user.UserId + " has been changed!");

            context.SaveChanges();

        }

        public static void AssignUserRole(Int32 userId, UserRoles role) 
        {
            UserContext context = new UserContext();
            // old way
           /* foreach (User user in TestUsersList)
            {
                if (user.username == username)
                {
                    user.role = role;
                    Logger.LogActivity("The role to: " + user.username + " has been changed!");
                }
            }*/

            User user = (from u in context.Users
                         where u.UserId == userId
                         select u).First();
            user.role = role;
            Logger.LogActivity("The role to user with id: " + user.UserId + " has been changed!");
            context.SaveChanges();

        }




    }
}
