using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNikola
{
   
   public class LoginValidation
    {

        public static UserRoles currentUserRole { get; private set; }

        //delegate
        public delegate void ActionOnError(String errorMsg);

        private ActionOnError aon1;


        private String _username;
        private String _password;
        private String _errorLog;


        public LoginValidation(String _username, String _password, ActionOnError aon1)
        {   
            this._username = _username;
            this._password = _password;
            this.aon1 = aon1;
        }

    public bool ValidateUserInput(ref User u)
        {



            u = UserData.isUserPassCorrect(_username,_password);

            if(u == null)
            {
                _errorLog = "Wrong username or password";
                currentUserRole = UserRoles.ANONYMOUS;
               
                aon1(_errorLog);

                return false;
            }

            Boolean emptyUserName;
            emptyUserName = _username.Equals(String.Empty);

            if (emptyUserName)
            {
                _errorLog = "There is no username entered";
                currentUserRole = UserRoles.ANONYMOUS;
                aon1(_errorLog);
                return false;
            }
            Boolean isEmptyPassword;
            isEmptyPassword = _password.Equals(String.Empty);

            if (isEmptyPassword)
            {
                _errorLog = "There is no password entered";
                currentUserRole = UserRoles.ANONYMOUS;
                aon1(_errorLog);
                return false;
            }

            if (_password.Length < 5)
            {
                
                _errorLog = "The password lenght must be 5 or higher";
                currentUserRole = UserRoles.ANONYMOUS;
                aon1(_errorLog);
                return false;
            }

            if(_username.Length < 5)
            {
                _errorLog = "The username lenght must be 5 or higher";
                currentUserRole = UserRoles.ANONYMOUS;
                aon1(_errorLog);
                return false;
            }



            currentUserRole = u.role;
            Logger.LogActivity("You logged in successfully!");
            return true;
        }

    }
}
