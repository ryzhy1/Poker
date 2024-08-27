using OOP_ICT.Second.Models.Bank;

namespace OOP_ICT.Second.Models.Factories;

public class BankAccountFactory : AccountFactory
{
    public override BankAccount CreateAccount(int playerID, uint money)
    {
        return new BankAccount(playerID, money);
    }
}