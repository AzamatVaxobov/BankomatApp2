using BankomatApp.Services;
using Serilog;

namespace BankomatApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

            var service = new BankomatService();

            var password = string.Empty;

            var isPasswordReal = false;

            for (var i = 0; i < 3; i++)
            {
                Console.Write("Enter password : ");
                password = Console.ReadLine();
                isPasswordReal = service.CheckPassword(password);
                if (isPasswordReal)
                {
                    break;
                }
                Log.Error("Password incorrect try again");
            }

            if (isPasswordReal == false)
            {
                Log.Error("Your card blocked");
                return;
            }

            var choice = string.Empty;
            var balance = 0m;
            var newPassword = string.Empty;
            var confirmationCode = string.Empty;
            var phoneNumber = string.Empty;
            var phoneNumber1 = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.CheckBalance");
                Console.WriteLine("2.GetCash");
                Console.WriteLine("3.AddBalance");
                Console.WriteLine("4.ChangePassword");
                Console.WriteLine("5.ConnectPhoneNumber");
                Console.WriteLine("6.GetPhoneNumber");


                Console.Write("Enter : ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    balance = service.CheckBalance();
                    Console.WriteLine($"Your balance {balance}");
                }
                else if (choice == "2")
                {
                    Console.Write("Enter amount of cash : ");
                    balance = Convert.ToDecimal(Console.ReadLine());
                    var result = service.GetCash(balance);
                    if (result) Console.WriteLine("Successfully Withdrawed");
                    else Log.Error("Error occured");
                }
                else if (choice == "3")
                {
                    Console.Write("Enter amount of cash : ");
                    balance = Convert.ToDecimal(Console.ReadLine());
                    var result = service.AddBalance(balance);
                    if (result) Console.WriteLine("Successfull Added");
                    else Log.Error("Error occured");
                }
                else if (choice == "4")
                {
                    Console.Write("Enter new password ");
                    newPassword = Console.ReadLine();
                    Console.Write("Enter Confirmation Code ");
                    confirmationCode = Console.ReadLine();
                    var result = service.ChangePaswword(newPassword, confirmationCode);
                    if (result) Console.WriteLine("Successfull Changed");
                    else Log.Error("Error occured");


                }
                else if (choice == "5")
                {
                    Console.Write("Enter phone number to connect card ");
                    phoneNumber = Console.ReadLine();
                    var result = service.ConnectPhoneNumber(phoneNumber);
                    if (result) Console.WriteLine("Successfull Connected");
                    else Log.Error("Error occured");


                }
                else if (choice == "6")
                {
                    Console.Write("Enter phone number  ");
                    phoneNumber1 = Console.ReadLine();
                    var result = service.GetPhoneNumber();
                    if (result == string.Empty) Log.Information("There is no connected phone number");
                    else Console.WriteLine(result);

                }

                Console.ReadKey();
            }


        }
    }
}
