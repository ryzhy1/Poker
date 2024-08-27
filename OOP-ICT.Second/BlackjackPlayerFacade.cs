using OOP_ICT.First.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Bank;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Second;

public class BlackjackPlayerFacade
{
    private int _bet;
    private BlackjackPlayer _player;

    public BlackjackPlayerFacade
        (BlackjackPlayer player)
    {
        _player = player;
    }

    public void CreateAccount(IPayment payment, uint money, BlackjackPlayer player)
    {
        payment.CreateAccount(player, money);
    }

    public void Deposit(IPayment payment, uint money, BlackjackPlayer player)
    {
        payment.Deposit(player, money);
    }

    public void Withdraw(IPayment payment, uint money, BlackjackPlayer player)
    {
        payment.Withdraw(player, money);
    }

    public void Play(int pointsForAce, List<Card> dealersCards, Bank bank,
        BlackjackCasino casino)
    {
        _bet = new GameLogic().Play(pointsForAce, dealersCards, bank, casino, _player, _bet);
    }
    public void MakeBet(IPayment payment,int chips)
    {
        payment.Withdraw(_player,(uint)chips);
        _bet = chips;
    }
}