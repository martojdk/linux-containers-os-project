using System;
using System.Collections.Generic;

namespace UserLogin
{
    public class LoginValidator
    {
        private string UserName;
        private string Pwd;
        private string ErrMsg;
        private ActionOnError actionOnError;
        static public UserRoles CurrentUserRole { get; private set; }
        static public string CurrentUsername { get; private set; }

        public LoginValidator(string userName, string pwd,ActionOnError _actionOnError)
        {
            UserName = userName;
            Pwd = pwd;
            actionOnError = _actionOnError;

        }

        public bool ValidateUserInput(ref User user)
        { 
            user = new User();
            if (UserName.Equals(String.Empty))
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError("Empty username");
                return false;
            }
            if(Pwd.Length < 5)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError("Pwd less than 5 chars");
                return false;
            }
            if (Pwd.Equals(String.Empty))
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError("Empty password");
                return false;

            }
            user = UserData.IsUserPassCorrect(UserName, Pwd);
            if(user == null)
            {
                ErrMsg = "User not found in database";
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(ErrMsg);
                return false;
            }
           
            Console.WriteLine(user.ToString());
            CurrentUserRole = (UserRoles)user.getRole();
            CurrentUsername = UserName;
            Logger.LogActivity("Успешен Login");
            return true;
        }

        public delegate void ActionOnError(string errorMsg);

        

    }
}
