using OOP_ICT.First.Models;
using OOP_ICT.Fourth.Combinations;
using OOP_ICT.Second.Models.Interfaces;
using Player = OOP_ICT.First.Models.Player;

namespace OOP_ICT.Fourth;

public class PokerPlayer : Player
{
    private PokerPlayerFacade _playerFacade;
    private List<Card> _cards;
    public readonly int Id;
    public uint Balance { get; private set; }
    
    public PokerPlayer(int id, uint balance) : base(id, balance)
    {
        Id = id;
        Balance = balance;
        _playerFacade = new PokerPlayerFacade(this);
        _cards = new List<Card>();
    }
    
    public void CreateAccount(IPayment payment, uint money, PokerPlayer player)
    {
        _playerFacade.CreateAccount(payment,money,player);
        Balance -= money;
    }
    
    public void Deposit(IPayment payment, uint money, PokerPlayer player)
    {
        _playerFacade.Deposit(payment,money,player);
        Balance -= money;
    }
    
    public void Withdraw(IPayment payment, uint money, PokerPlayer player)
    {
        _playerFacade.Withdraw(payment,money,player);
        Balance += money;
    }
    public void TakeCard(Card card)
    {
        _cards.Add(card);
    }

    public IReadOnlyList<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }
    
    public uint MakeBet(PokerCasino pokerCasino, PokerPlayer player, uint bitcoins)
    {
        _playerFacade.MakeBet(pokerCasino, player, bitcoins);
        return bitcoins;
    }
    
    public int GetBestCombination(List<Card> tableCards)
    {
        foreach (var card in tableCards)
        {
            _cards.Add(card);
        }

        List<PokerCombination> results = new List<PokerCombination>();
        
        Chain careCombinationChecker = new CareChain();
        Chain flashCombinationChecker = new FlashChecker();
        Chain fullHouseCombinationChecker = new FullHouseChecker();
        Chain pairCombinationChecker = new PairChecker();
        Chain royalCombinationChecker = new RoyalFlashChecker();
        Chain streetCombinationChecker = new StreetChecker();
        Chain streetFlashCombinationChecker = new StreetFlashChecker();
        Chain threeCombinationChecker = new ThreeChecker();
        Chain twoPairsCombinationChecker = new TwoPairsChecker();
        
        results.Add(careCombinationChecker.GetChainResult(_cards));
        results.Add(careCombinationChecker.DetermineResult(flashCombinationChecker, _cards));
        results.Add(flashCombinationChecker.DetermineResult(fullHouseCombinationChecker, _cards));
        results.Add(fullHouseCombinationChecker.DetermineResult(pairCombinationChecker, _cards));
        results.Add(pairCombinationChecker.DetermineResult(royalCombinationChecker, _cards));
        results.Add(royalCombinationChecker.DetermineResult(streetCombinationChecker, _cards));
        results.Add(streetCombinationChecker.DetermineResult(streetFlashCombinationChecker, _cards));
        results.Add(streetFlashCombinationChecker.DetermineResult(threeCombinationChecker, _cards));
        results.Add(threeCombinationChecker.DetermineResult(twoPairsCombinationChecker, _cards));

        return (int)results.Max();
    }
    
    public void Fold()
    {
        _cards.Clear();
    }
}