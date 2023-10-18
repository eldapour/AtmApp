using AtmApp.database;
using AtmApp.entities;
using System;
using System.Linq;

namespace AtmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Welcome to Atm App Console");
            Console.WriteLine("---------------------------");

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. login");
            Console.WriteLine("2. create Account");
            Console.WriteLine("3. Exit");
            bool exit = false;

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int code = login().Code;
                if (code != null)
                {
                    do
                    {

                        Console.WriteLine("\nMenu:");
                        Console.WriteLine("1. Withdraw money : ");
                        Console.WriteLine("2. Deposit Money : ");
                        Console.WriteLine("3. Exit");
                        Console.Write("Select an option: ");

                        choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            withdraw(code);
                        }
                        else if (choice == "2")
                        {
                            Deposit(code);
                        }
                        else if (choice == "3")
                        {
                                exit = true;
                                Console.WriteLine("Exit Successfully !");
                        }

                    } while (exit != true);
                }

            }
            else if (choice == "2")
            {
                dbContainer db = new dbContainer();
                Console.WriteLine("Welcome To The Atm App");
                Console.WriteLine("Enter Your Full Name : ");
                string FName = Console.ReadLine();
                Console.WriteLine("Enter Your Password : ");
                string _Password = Console.ReadLine();
                int Password = int.Parse(_Password);

                Random _code = new Random();
                int Code = _code.Next(500, 999999);

                var NewAccount = new Account() { FullName = FName, Password = Password, Code = Code, Status = true };

                db.Accounts.Add(NewAccount);
                db.SaveChanges();

                if (true)
                {
                    Console.WriteLine("Account Created Successfully Your code : {0} , Your Password : {1}", Code, Password);
                }
            }
            else if (choice == "3")
            {
                exit = true;
                Console.WriteLine("Exit Successfully !");
            }     
        }

        public static Account login()
        {
            dbContainer db = new dbContainer();

            Console.WriteLine("Please Enter Your Account code :");
            string AccCodeS = Console.ReadLine();
            int AccCode = int.Parse(AccCodeS);

            Console.WriteLine("Please Enter Your Account Password :");
            string AccPassS = Console.ReadLine();
            int AccPass = int.Parse(AccPassS);

            var Account = db.Accounts.Where(a => a.Code == AccCode && a.Password == AccPass).FirstOrDefault();

            if (Account != null)
            {
                Console.WriteLine("Welcome {0} TO ACCOUNT YOUR WALLE : {1}", Account.FullName, Account.Money);
                return Account;
            }
            else
            {
                Console.WriteLine("Login failed. Please check your account code and password.");
                return null;
            }
        }
        public static void withdraw(int code)
        {
            dbContainer db = new dbContainer();
            var Account = db.Accounts.Where(a => a.Code == code).FirstOrDefault();
            Console.WriteLine("Enter the amount of money you wish to withdraw : ");
            string MoneyStr = Console.ReadLine();
            int Money = int.Parse(MoneyStr);
            Account.Money += Money;
            db.SaveChanges();

            Console.WriteLine("YOUR WALLE Now : {0}", Account.Money);
        }

        public static void Deposit(int code)
        {
            dbContainer db = new dbContainer();
            var Account = db.Accounts.Where(a => a.Code == code).FirstOrDefault();

            Console.WriteLine("Enter the amount of money you wish to Deposit : ");
            string MoneyStr = Console.ReadLine();
            int Money = int.Parse(MoneyStr);
            Account.Money -= Money;
            db.SaveChanges();

            Console.WriteLine("YOUR WALLE Now : {0}", Account.Money);
        }



    }
}