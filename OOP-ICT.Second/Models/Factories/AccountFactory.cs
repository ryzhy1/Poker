using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Second.Models.Factories;

public abstract class AccountFactory
{
    public abstract IAccount CreateAccount(int playerID, uint money);
}