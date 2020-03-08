using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Program
    {
        private static List<DateTime> loginDates = new List<DateTime>();
        public static void logErrorMsg(string errorMsg)
        {
            Console.WriteLine(errorMsg);
        }
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Password:");
                string pwd = Console.ReadLine();

                User admin = new User();
                LoginValidator loginValidator = new LoginValidator(name, pwd, logErrorMsg);
                if (loginValidator.ValidateUserInput(ref admin))
                {
                    UserRoles role = (UserRoles)admin.getRole();

                    switch (role)
                    {
                        case UserRoles.ADMIN:
                            Console.WriteLine("User is admin");
                            OperateAdmin();
                            break;
                        case UserRoles.ANONYMOUS:
                            Console.WriteLine("User is nobody");
                            break;
                        case UserRoles.INSPECTOR:
                            Console.WriteLine("User is ispector");
                            break;
                        case UserRoles.STUDENT:
                            Console.WriteLine("User is student");
                            break;
                        case UserRoles.PROFESSOR:
                            Console.WriteLine("User is professor");
                            break;
                        default:
                            Console.WriteLine("User role not found ");
                            break;
                    }
                } else
                {
                    loginDates.Add(DateTime.Now);
                    if(loginDates.Count == 3 && AreLoginsInRangeOfTwoMinutes())
                    {
                        Console.WriteLine("3 Login attemts reached.Now you cant login anymore");
                        Logger.LogActivity("Limit for login attemts 3 reached");
                        break;
                    }
                }
            }
        }

        static private bool AreLoginsInRangeOfTwoMinutes()
        {
            TimeSpan span = loginDates[2].Subtract(loginDates[0]);
            if (span.TotalMinutes <= 2)
            {
                return true;
            }
            return false;
        }


        static void OperateAdmin()
        {
            Console.WriteLine("0.Izhod\n1.Promqna na rolq na user\n2.Promqna na aktivnost na user\n3.Spisyk na useri\n4.Otvori loga\n5.Aktivnost");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    changeUserRole();
                    break;
                case 2:
                    ChangeUserActivity();
                    break;
                case 3:
                    PrintUserList();
                    break;
                case 4:
                    Logger.readLogFile();
                    break;
                case 5:
                    Logger.ReadActivity();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Wrong number chosen");
                    break;
            }
        }

        static void changeUserRole()
        {
            Console.WriteLine("Input username for role change");
            string name = Console.ReadLine();
            Console.WriteLine("Input new role for user");
            Int32 role = Int32.Parse(Console.ReadLine());
            UserData.AssignUserRole(name, (UserRoles)role);
        }

        static void ChangeUserActivity()
        {
            Console.WriteLine("Input username for activity change");
            string name = Console.ReadLine();
            Console.WriteLine("Input activity for user");
            UserData.SetUserActive(name, DateTime.Parse(Console.ReadLine()));

        }

        static void PrintUserList()
        {
            foreach(User u in UserData.TestUsers)
            {
                Console.WriteLine(u);
            }
        }


    }
}
