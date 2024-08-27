using OOP_ICT.Second.Models.Exceptions;
using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Second.Models.Casino;

public class CasinoAccount : IAccount
{
    public uint Bitcoins { get; private set; }

    public int PlayerID;

    public CasinoAccount(int playerID, uint money)
    {
        Bitcoins = money;
        PlayerID = playerID;
    }
    
    public void Deposit(uint money)
    {
        Bitcoins += money;
    }

    public void Withdraw(uint money)
    {
        if (Bitcoins < money)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        Bitcoins -= money;
    }
}