using System.Runtime.CompilerServices;
using OOP_ICT.First.Models;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Interfaces;
using OOP_ICT.Second.Models.Bank;
namespace OOP_ICT.Second.Models;

public class PlayerAccount : Player
{
    public readonly int Id;
    private PlayerFacade _playerFacade;
    private List<Card> _cards;

    public uint Balance { get; private set; }
    
    public PlayerAccount(int id, uint balance) : base(id, balance)
    {
        Id = id;
        Balance = balance;
        _playerFacade = new PlayerFacade(this);
        _cards = new List<Card>();
    }
    
    public void CreateAccount(IPayment payment, uint money, PlayerAccount player)
    {
        _playerFacade.CreateAccount(payment,money,player);
        Balance -= money;
    }
    
    public void Deposit(IPayment payment, uint money, PlayerAccount player)
    {
        _playerFacade.Deposit(payment,money,player);
        Balance -= money;
    }
    
    public void Withdraw(IPayment payment, uint money, PlayerAccount player)
    {
        _playerFacade.Withdraw(payment,money,player);
        Balance += money;
    }

    public void Play(int pointsForAce, List<Card> dealersCards, Bank.Bank bank,
        BlackjackCasino casino)
    {
        _playerFacade.Play(pointsForAce,dealersCards,bank,casino);
    }

    public void TakeCard(Card card)
    {
        _cards.Add(card);
    }

    public IReadOnlyList<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }
    
    public void MakeBet(IPayment payment,int chips)
    {
        _playerFacade.MakeBet(payment,chips);
    }
}