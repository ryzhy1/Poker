using OOP_ICT.First.Models;
using OOP_ICT.Second.Models.Exceptions;
using OOP_ICT.Second.Models.Factories;
using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Second.Models.Bank;

public class Bank : IPayment
{
    private readonly Dictionary<int, BankAccount> _bankAccounts;

    private readonly BankAccountFactory _bankAccountFactory;

    public Bank(BankAccountFactory bankAccountFactory)
    {
        _bankAccounts = new Dictionary<int, BankAccount>();
        _bankAccountFactory = bankAccountFactory;
    }
    
    public void CreateAccount(Player player, uint money)
    {
        if (money > player.Balance)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        
        if (_bankAccounts.ContainsKey(player.Id))
        {
            throw new AccountAlreadyExistsException("The account already exists");
        }
        _bankAccounts.Add(player.Id, _bankAccountFactory.CreateAccount(player.Id, money));
    }

    public void Deposit(Player player, uint money)
    {
        if (money > player.Balance)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        
        if (!_bankAccounts.ContainsKey(player.Id))
        {
            throw new AccountDoesNotExistException("Account not found");
        }
        _bankAccounts[player.Id].Deposit(money);
    }

    public void Withdraw(Player player, uint money)
    {
        if (money > player.Balance)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        
        if (!_bankAccounts.ContainsKey(player.Id))
        {
            throw new AccountDoesNotExistException("Account not found");
        } 
        _bankAccounts[player.Id].Withdraw(money);
    }
    
    public BankAccount GetPlayerAccount(int playerID)
    {
        if (!_bankAccounts.ContainsKey(playerID))
        {
            throw new AccountDoesNotExistException("Account not found");
        }
        return _bankAccounts[playerID];
    }
}