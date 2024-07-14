namespace BankomatApp.Services;

public interface IBankomatService
{
    string GetPhoneNumber();
    bool ConnectPhoneNumber(string _phoneNumber);
    bool ChangePaswword(string _newPassword, string _confirmationPassword);
    bool CheckPassword(string _password);
    bool GetCash(decimal amountCash);
    decimal CheckBalance();
    bool AddBalance(decimal _balance);
    string GetPassword();
}
