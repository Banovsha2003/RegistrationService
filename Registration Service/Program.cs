using System;

namespace Registration_Service
{
    internal class Program
    {
        //Global Data
        static string[] nicknames = new string[10];
        static string[] passwords = new string[10];

        static void Main(string[] args)
        {
            //Initialize Data
            SeedData();

            ApplicationStartWindow();
        }

        static void SeedData()
        {
            nicknames[0] = "Faiq";
            passwords[0] = "salam123";

            nicknames[1] = "Turan";
            passwords[1] = "salam123";

            nicknames[2] = "Razor";
            passwords[2] = "salam123";

        }


        static void ApplicationStartWindow()
        {
            //Reset Color when Application starts
            Console.ResetColor();

            Console.Title = "Clash of Clans";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome");
            Console.ResetColor();

            //Options
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SignIn();
            }
            else if (choice == "2")
            {
                SignUp();
            }
        }

        static void SignIn()
        {
            Console.Clear();
            Console.BackgroundColor= ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------->Sing In Form<-------------------------");
            Console.ResetColor();
            Console.WriteLine("Enter Your Nickname: ");
            string nickName = Console.ReadLine();

            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            while (FindUser(nickName, password) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("This User is't exists. Please Enter new User: ");
                Console.ResetColor();
                nickName = Console.ReadLine();
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to");
            Console.ResetColor();
            Console.ReadKey();
        }
        private static bool FindPassword(string password)
        {
            foreach (var passWord in passwords)
            {
                if (passWord == password)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool FindUser(string nickName, string password)
        {
            int index = 0;
            foreach (var nickname in nicknames)
            {
                if (nickname == nickName)
                {
                    break;
                }
                index++;
            }
            for (int i = 0; i < passwords.Length; i++)
            {
                if (passwords[index] == password)
                {
                    return true;
                }
            }
            return false;
        }

        static void SignUp()
        {

            //Clear All Data from Console
            Console.Clear();

            //Header
            Console.BackgroundColor= ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------------------------------>Sing Up Form<-------------------------------");
            Console.ResetColor();

            // Registration Form
            Console.WriteLine("Enter Your Nickname: ");
            string nickName = Console.ReadLine();

            while (CheckNickName(nickName) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("This NickName already exists. Please Enter new NickName: ");
                Console.ResetColor();
                nickName = Console.ReadLine();

            }

            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();

            while (CheckPassword(password) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Password is invalid. Password must contain at least 1 UpperCase, 1 Digit, 1 Symbol and length 12");
                Console.ResetColor();
                password = Console.ReadLine();

            }

           


        }

        static bool CheckNickName(string nickName)
        {
            bool notExist = true;

            for (int i = 0; i < nicknames.Length; i++)
            {
                if (nicknames[i] == nickName)
                {
                    notExist = false;
                    break;
                }
            }

            return notExist;
        }

        static bool CheckPassword(string password)
        {
            if (password.Length < 12) return false;

            bool hasDigit = false;
            bool hasSymbol = false;
            bool hasUpper = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i])) hasDigit = true;
                if (char.IsUpper(password[i])) hasUpper = true;
                if (char.IsSymbol(password[i])) hasSymbol = true;
            }

            if (hasDigit && hasSymbol && hasUpper) return true;

            return false;
        }
    }
}
