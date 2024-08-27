using OOP_ICT.Second.Models.Casino;

namespace OOP_ICT.Second.Models.Factories;

public class CasinoAccountFactory : AccountFactory
{
    public override CasinoAccount CreateAccount(int playerID, uint money)
    {
        return new CasinoAccount(playerID, money);
    }
}