using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3Library;

namespace Tema3
{

    class Program
    {
        private static CommonBoard commonBoard;

        private static void DisplayMenuAccountOrLogIn()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create another account");
            Console.WriteLine("2 - Log in");
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create another account");
            Console.WriteLine("2 - Log in with another account");
            Console.WriteLine("3 - Post message as current user.");
            Console.WriteLine("4 - See sorted messages");
            Console.WriteLine("5 - Exit");
        }

        private static User CreateAccount()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter year of birth (yyyy): ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter month of birth (1-12): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day of birth (1-31): ");
            int day = int.Parse(Console.ReadLine());

            string userName;
            int countUserName = 0;
            
            do
            {
                if (countUserName == 0)
                {
                    Console.Write("Enter your username: ");
                }
                else
                {
                    Console.Write("Your username was already used, please insert another one: ");
                }
                userName = Console.ReadLine();
                countUserName++;
            } while (!commonBoard.CheckIfUserNameWasUsed(userName));
            
            Console.Write("Enter your email: ");
            string userEmail = Console.ReadLine();

            Console.Write("Enter your password: ");
            string userPassword = Console.ReadLine();

            return commonBoard.AddUser(firstName, lastName, new DateTime(year, month, day), userName, userEmail, userPassword);
        }

        private static User LogIn()
        {
            Console.Write("Please enter below your username and password.\n");

            string userNameToBeChecked;
            int countUserName = 0;

            do
            {
                if (countUserName == 0)
                {
                    Console.Write("Username: ");
                }
                else
                {
                    Console.Write("Incorect or invalid username, please try again: ");
                }
                userNameToBeChecked = Console.ReadLine();
                countUserName++;
            } while (commonBoard.CheckIfUserNameWasUsed(userNameToBeChecked));

            string userPasswordToBeChecked;
            int countPassword = 0;

            do
            {
                if (countPassword == 0)
                {
                    Console.Write("Password: ");
                }
                else
                {
                    Console.Write("Incorect or invalid password, please try again: ");
                }
                userPasswordToBeChecked = Console.ReadLine();
                countPassword++;
            } while (commonBoard.CheckIfPasswordIsCorrect(userNameToBeChecked,userPasswordToBeChecked));
            
            return commonBoard.GetUserByUserName(userNameToBeChecked);
        }

        private static Message AddPost()
        {
            
            Console.Write("Please enter below your message.\n");

            string userMessage = Console.ReadLine();
            DateTime currentDate = DateTime.Now;

            return commonBoard.AddMessage(userMessage, currentDate);
        }

        private static void GetSortedPosts(CommonBoard commonBoardUser)
        {
            List<Message> messages = commonBoardUser.GetOrderedMessages();

            foreach (Message message in messages)
            {
                Console.WriteLine(message.MessageContent);
                Console.WriteLine(message.MessagePostTime);
            }
        }

        static void Main(string[] args)
        {
            commonBoard = new CommonBoard(new UserService(), new MessageService());

            Console.Write("Create your first account:\n");
            CreateAccount();

            bool loggedInOrNot = false;

            do
            {
                DisplayMenuAccountOrLogIn();

                Console.Write("Your option is: ");
                int option = 0;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        LogIn();
                        loggedInOrNot = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again!");
                        break;
                }
            } while(!loggedInOrNot);

            while (true)
            {
                DisplayMenu();

                Console.Write("Your option is: ");
                int option = 0;
                int.TryParse(Console.ReadLine(), out option);

                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        AddPost();
                        break;
                    case 4:
                        GetSortedPosts(commonBoard);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again!");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
