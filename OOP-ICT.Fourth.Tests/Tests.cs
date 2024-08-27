using OOP_ICT.First.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models.Factories;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class Tests
{
    [Fact]
    public void TestPokerGame()
    {
        List<PokerPlayer> pokerPlayers = new List<PokerPlayer>();
        
        var pokerCasino = new PokerCasino(new CasinoAccountFactory());
        var pokerPlayer1 = new PokerPlayer(1, 50);
        var pokerPlayer2 = new PokerPlayer(2, 50);
        var dealer = new Dealer();
        var table = new Table();

        pokerPlayer1.CreateAccount(pokerCasino, 50, pokerPlayer1);
        pokerPlayer2.CreateAccount(pokerCasino, 50, pokerPlayer2);
        
        pokerPlayers.Add(pokerPlayer1);
        pokerPlayers.Add(pokerPlayer2);

        var pokerGame = new PokerGameFacade(pokerCasino, pokerPlayers, 0);
        pokerGame.StartGame(pokerCasino, dealer, 10, 20, table);

        Assert.Equal(2, pokerPlayer1.GetCards().Count);
        Assert.Equal(2, pokerPlayer2.GetCards().Count);
        Assert.Equal(3, table.Cards.Count);
        pokerPlayer1.Fold();
        Assert.Empty(pokerPlayer1.GetCards());
    }

    [Fact]
    public void TestPokerGameWinner()
    {
        List<PokerPlayer> pokerPlayers = new List<PokerPlayer>();
        
        var pokerCasino = new PokerCasino(new CasinoAccountFactory());
        var pokerPlayer1 = new PokerPlayer(1, 50);
        var pokerPlayer2 = new PokerPlayer(2, 50);
        var dealer = new Dealer();
        var table = new Table();

        pokerPlayer1.CreateAccount(pokerCasino, 50, pokerPlayer1);
        pokerPlayer2.CreateAccount(pokerCasino, 50, pokerPlayer2);
        
        pokerPlayers.Add(pokerPlayer1);
        pokerPlayers.Add(pokerPlayer2);

        var pokerGame = new PokerGameFacade(pokerCasino, pokerPlayers, 0);
        pokerGame.StartGame(pokerCasino, dealer, 10, 20, table);

        pokerPlayer1.MakeBet(pokerCasino, pokerPlayer1, 0); 

        Assert.Equal(pokerPlayer1, pokerGame.GetWinner(table));
    }

    [Fact]
    public void TestRoyalFlushCombination()
    {
        var pokerPlayer1 = new PokerPlayer(1, 50);
        
        var cards = new List<Card>
        {
            new Card(Suit.Hearts, Rank.Ace),
            new Card(Suit.Hearts, Rank.King),
            new Card(Suit.Hearts, Rank.Jack),
            new Card(Suit.Hearts, Rank.Queen),
            new Card(Suit.Hearts, Rank.Ten)
        };

        pokerPlayer1.GetBestCombination(cards);

        var combination = pokerPlayer1.GetBestCombination(cards);

        Assert.Equal(10, combination);
    }

    [Fact]
    public void TestStraightFlushCombination()
    {
        var pokerPlayer1 = new PokerPlayer(1, 50);
        
        var cards = new List<Card>
        {
            new Card(Suit.Hearts, Rank.Nine),
            new Card(Suit.Hearts, Rank.Eight),
            new Card(Suit.Hearts, Rank.Seven),
            new Card(Suit.Hearts, Rank.Six),
            new Card(Suit.Hearts, Rank.Five)
        };
    
        var combination = pokerPlayer1.GetBestCombination(cards);
        
        Assert.Equal(9, combination);
    }
    
    [Fact]
    public void TestFullHouseCombination()
    {
        var pokerPlayer1 = new PokerPlayer(1, 50);
        
        var cards = new List<Card>
        {
            new Card(Suit.Hearts, Rank.Ace),
            new Card(Suit.Club, Rank.Ace),
            new Card(Suit.Diamond, Rank.Ace),
            new Card(Suit.Spade, Rank.King),
            new Card(Suit.Hearts, Rank.King)
        };
    
        var combination = pokerPlayer1.GetBestCombination(cards);
    
        Assert.Equal(7, combination);
    }
}