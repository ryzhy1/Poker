using OOP_ICT.First.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Bank;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Interfaces;
public class PlayerFacade
{
    private int _bet;
    private PlayerAccount _player;
    private BlackjackPlayer _player1;

    public PlayerFacade(PlayerAccount player)
    {
        _player = player;
    }

    public void CreateAccount(IPayment payment, uint money, PlayerAccount player)
    {
        payment.CreateAccount(player, money);
    }

    public void Deposit(IPayment payment, uint money, PlayerAccount player)
    {
        payment.Deposit(player, money);
    }

    public void Withdraw(IPayment payment, uint money, PlayerAccount player)
    {
        payment.Withdraw(player, money);
    }

    public void Play(int pointsForAce, List<Card> dealersCards, Bank bank,
        BlackjackCasino casino)
    {
        _bet = new GameLogic().Play(pointsForAce, dealersCards, bank, casino, _player1, _bet);
    }
    public void MakeBet(IPayment payment,int chips)
    {
        payment.Withdraw(_player,(uint)chips);
        _bet = chips;
    }
}