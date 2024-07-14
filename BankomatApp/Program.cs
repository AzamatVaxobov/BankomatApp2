using BankomatApp.Services;

namespace BankomatApp;

internal class Program
{
    static void Main(string[] args)
    {

        IBankomatService atmService = new BankomatService();
        ILoggingService logService = new LoggingService();

        var password = string.Empty;

        var isPasswordReal = false;

        for (var i = 0; i < 3; i++)
        {
            logService.LogInfo("Enter password : ");
            password = Console.ReadLine();
            isPasswordReal = atmService.CheckPassword(password);
            if (isPasswordReal)
            {
                break;
            }
            logService.LogInfo("Password incorrect try again");
            atmService.CheckBalance();
        }

        if (isPasswordReal == false)
        {
            logService.LogInfo("Your card blocked");
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
            logService.LogInfo("1.CheckBalance");
            logService.LogInfo("2.GetCash");
            logService.LogInfo("3.AddBalance");
            logService.LogInfo("4.ChangePassword");
            logService.LogInfo("5.ConnectPhoneNumber");
            logService.LogInfo("6.GetPhoneNumber");
            logService.LogInfo("7.GetPassword");
            logService.LogInfo("8.Exit");


            logService.LogInfo("Enter : ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                balance = atmService.CheckBalance();
                logService.LogInfo($"Your balance {balance}");
            }
            else if (choice == "2")
            {
                logService.LogInfo("Enter amount of cash : ");
                balance = Convert.ToDecimal(Console.ReadLine());
                var result = atmService.GetCash(balance);
                if (result) logService.LogInfo("Successfully Withdrawed");
                else logService.LogError("Error occured");
            }
            else if (choice == "3")
            {
                logService.LogInfo("Enter amount of cash : ");
                balance = Convert.ToDecimal(Console.ReadLine());
                var result = atmService.AddBalance(balance);
                if (result) logService.LogInfo("Successfull Added");
                else logService.LogError("Error occured");
            }
            else if (choice == "4")
            {
                logService.LogInfo("Enter password  ");
                password = Console.ReadLine();
                logService.LogInfo("Enter new password ");
                newPassword = Console.ReadLine();
                logService.LogInfo("Confirm password ");
                confirmationCode = Console.ReadLine();
                var result1 = atmService.CheckPassword(password);
                var result2 = atmService.ChangePaswword(newPassword, confirmationCode);
                if (result1 && result2) logService.LogInfo("Successfull Changed");
                else logService.LogError("Error occured");
            }
            else if (choice == "5")
            {
                logService.LogInfo("Enter phone number to connect card ");
                phoneNumber = Console.ReadLine();
                var result = atmService.ConnectPhoneNumber(phoneNumber);
                if (result) logService.LogInfo("Successfull Connected");
                else logService.LogError("Error occured");
            }
            else if (choice == "6")
            {
                var result = atmService.GetPhoneNumber();
                if (result == string.Empty) logService.LogInfo("There is no connected phone number");
                else logService.LogInfo("Phone number is : " + result);
            }
            else if(choice == "7")
            {
                var result = atmService.GetPassword();
                logService.LogInfo($"Your password is {result}");
            }
            else if(choice == "8")
            {
                return;
            }

            Console.ReadKey();
        }
    }
}
