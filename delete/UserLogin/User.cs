using System;
namespace UserLogin
{
    public class User
    {
        string UserName;
        string Pwd;
        string FacultyNumber;
        int Role;
        public DateTime Created;
           
        public User()
        {
        }

        public User(string userName, string pwd, string facultyNumber, int role)
        {
            UserName = userName;
            Pwd = pwd;
            FacultyNumber = facultyNumber;
            Role = role;
        }

        public string getUserName()
        {
            return UserName;
        }

        public void setUserName(string value)
        {
            this.UserName = value;
        }
        public string getPwd()
        {
            return Pwd;
        }

        public void setPwd(string value)
        {
            this.Pwd = value;
        }
        public string getFacultyNumber()
        {
            return FacultyNumber;
        }

        public void setFacultyNumber(string value)
        {
            this.FacultyNumber = value;
        }
        public int getRole()
        {
            return Role;
        }

        public void setRole(int value)
        {
            this.Role = value;
        }

        public override string ToString()
        {
            return string.Format("User with name %s , password %s, fac number %s, role %s", UserName, Pwd, FacultyNumber, Role);
        }
    }
}
