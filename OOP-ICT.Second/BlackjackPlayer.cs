using OOP_ICT.First.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Interfaces;

namespace OOP_ICT.Second;

public class BlackjackPlayer:Player
{
    public readonly int Id;
    private BlackjackPlayerFacade _playerFacade;
    private List<Card> _cards;

    public uint Balance { get; private set; }
    
    public BlackjackPlayer(int id, uint balance) : base(id, balance)
    {
        Id = id;
        Balance = balance;
        _playerFacade = new BlackjackPlayerFacade(this);
        _cards = new List<Card>();
    }
    
    public void CreateAccount(IPayment payment, uint money, BlackjackPlayer player)
    {
        _playerFacade.CreateAccount(payment,money,player);
        Balance -= money;
    }
    
    public void Deposit(IPayment payment, uint money, BlackjackPlayer player)
    {
        _playerFacade.Deposit(payment,money,player);
        Balance -= money;
    }
    
    public void Withdraw(IPayment payment, uint money, BlackjackPlayer player)
    {
        _playerFacade.Withdraw(payment,money,player);
        Balance += money;
    }

    public void Play(int pointsForAce, List<Card> dealersCards, Models.Bank.Bank bank,
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