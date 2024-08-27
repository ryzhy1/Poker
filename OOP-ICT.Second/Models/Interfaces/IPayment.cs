using OOP_ICT.First.Models;

namespace OOP_ICT.Second.Models.Interfaces;

public interface IPayment
{
    void CreateAccount(Player player, uint money);
    void Deposit(Player player, uint money);
    void Withdraw(Player player, uint money);
}
