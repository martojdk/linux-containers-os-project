using System;
using System.Collections.Generic;
using System.IO;

namespace UserLogin
{
    public static class UserData
    {
        public static List<User> TestUsers
        {
            get {
                return ResetUserData();
            }
            set {
                TestUsers = value;
            }
        }

        static private List<User> ResetUserData()
        {
            List<User>TestUsers1 = new List<User>();
            TestUsers1.Add(new User("Martin", "123456", "123955", 2));
            TestUsers1[0].Created = DateTime.MaxValue;
            TestUsers1.Add(new User("DotNetSucks", "dummy1", "239425", 5));
            TestUsers1[1].Created = DateTime.MaxValue;
            TestUsers1.Add(new User("FuckDotNet", "dummy2", "1234125", 5));
            TestUsers1[2].Created = DateTime.MaxValue;
            return TestUsers1;
        }

        static public User IsUserPassCorrect(string name,string pwd)
        {
            foreach(User u in TestUsers)
            {
                if(u.getUserName().Equals(name) && u.getPwd().Equals(pwd))
                {
                    return u;
                }
            }
            return null;
        }

        static public void SetUserActive(string username,DateTime newDate)
        {
            FindUserByName(username).Created = newDate;
            Logger.LogActivity("Change activity of " + username);
        }

        static public void AssignUserRole(string username,UserRoles userRole)
        {
            FindUserByName(username).setRole((int)userRole);
            Logger.LogActivity("Change role of " + username);
        }

        static public User FindUserByName(string name)
        {
            foreach (User u in TestUsers)
            {
                if (u.getUserName().Equals(name))
                {
                    return u;
                }
            }
            return null;
        }

        

        

}
}
