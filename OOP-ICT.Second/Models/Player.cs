using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Models;

public class Player
{
    public readonly int Id;

    public uint Balance { get; private set; }

    public Player(int id, uint balance)
    {
        Id = id;
        Balance = balance;
    }
    
    public void CreateAccount(IPayment payment, uint money, PlayerAccount player)
    {
        payment.CreateAccount(player, money);
        Balance -= money;
    }
    
    public void Deposit(IPayment payment, uint money, PlayerAccount player)
    {
        payment.Deposit(player, money);
        Balance -= money;
    }
    
    public void Withdraw(IPayment payment, uint money, PlayerAccount player)
    {
        payment.Withdraw(player, money);
        Balance += money;
    }
}