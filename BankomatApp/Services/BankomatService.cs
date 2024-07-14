namespace BankomatApp.Services;

public class BankomatService : IBankomatService
{
    private string password = "5555";
    private decimal balance = 500;
    private string phoneNumber = string.Empty;


    public string GetPhoneNumber()
    {
        return this.phoneNumber;
    }
    public bool ConnectPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) return false;
        if (!(phoneNumber.StartsWith("+998") && phoneNumber.Length == 13)) return false;
        this.phoneNumber = phoneNumber;
        return true;
    }
    public bool ChangePaswword(string newPassword, string confirmationPassword)
    {
        if (newPassword != confirmationPassword) return false;
        this.password = newPassword;
        return true;
    }

    public bool CheckPassword(string password)
    {
        return password == this.password;
    }

    public bool GetCash(decimal amountCash)
    {
        if (amountCash <= 0 || amountCash > this.balance) return false;
        this.balance -= amountCash;
        return true;
    }

    public decimal CheckBalance()
    {
        return this.balance;
    }

    public bool AddBalance(decimal balance)
    {
        if (balance <= 0) return false;
        this.balance += balance;
        return true;
    }

    public string GetPassword()
    {
        return this.password;
    }
}
