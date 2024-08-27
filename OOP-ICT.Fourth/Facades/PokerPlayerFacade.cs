using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Fourth;

public class PokerPlayerFacade
{
    private PokerPlayer _player;

    public PokerPlayerFacade
        (PokerPlayer player)
    {
        _player = player;
    }

    public void CreateAccount(IPayment payment, uint money, PokerPlayer player)
    {
        payment.CreateAccount(player, money);
    }

    public void Deposit(IPayment payment, uint money, PokerPlayer player)
    {
        payment.Deposit(player, money);
    }

    public void Withdraw(IPayment payment, uint money, PokerPlayer player)
    {
        payment.Withdraw(player, money);
    }
    
    public uint MakeBet(IPayment casino, PokerPlayer player, uint bitcoins)
    {
        casino.Withdraw(player, bitcoins);
        return bitcoins;
    }
    
    public uint AllIn(PokerCasino _pokerCasino)
    {
        uint totalBalance = _pokerCasino.GetPlayerAccount(_player.Id).Bitcoins;
        _pokerCasino.Withdraw(_player, totalBalance);
        return totalBalance;
    }
}