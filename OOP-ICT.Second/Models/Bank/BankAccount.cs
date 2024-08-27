using OOP_ICT.Second.Models.Exceptions;
using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Second.Models.Bank;

public class BankAccount : IAccount
{
    public uint Balance { get; private set; }

    private int _playerID;

    public BankAccount(int playerID, uint money)
    {
        Balance = money;
        _playerID = playerID;
    }
    
    public void Deposit(uint money)
    {
        Balance += money;
    }

    public void Withdraw(uint money)
    {
        if (Balance < money)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        Balance -= money;
    }
}