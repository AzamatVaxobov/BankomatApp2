namespace BankomatApp.Services;

public class BankomatService
{
    private string password = "5555";
    private decimal balance = 500;
    private string phoneNumber = string.Empty;


    public string GetPhoneNumber()
    {
        return phoneNumber;
    }
    public bool ConnectPhoneNumber(string _phoneNumber)
    {
        if(string.IsNullOrEmpty(_phoneNumber)) return false;
        if(!(_phoneNumber.StartsWith("+998") && _phoneNumber.Length == 13)) return false;
        phoneNumber = _phoneNumber;
        return true;
    }
    public bool ChangePaswword(string _newPassword, string _confirmationPassword)
    {
        if (_newPassword != _confirmationPassword) return false;
        password = _newPassword;
        return true;
    }

    public bool CheckPassword(string _password)
    {
        return _password == password;
    }

    public bool GetCash(decimal amountCash)
    {
        if (amountCash <= 0 || amountCash > balance) return false;
        balance -= amountCash;
        return true;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public bool AddBalance(decimal _balance)
    {
        if (_balance <= 0) return false;
        balance += _balance;
        return true;
    }
}
