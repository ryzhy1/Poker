using OOP_ICT.First.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Bank;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Factories;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class TestLab3
{
    [Fact]
    public void GetCardTest()
    {
        BlackjackPlayer player1 = new BlackjackPlayer(1, 15);
        Bank bank = new Bank(new BankAccountFactory());
        BlackjackCasino casino = new BlackjackCasino(new CasinoAccountFactory());
        bank.CreateAccount(player1,15);
        player1.TakeCard(new Card(Suit.Club,Rank.Ace));
        player1.TakeCard(new Card(Suit.Diamond,Rank.Five));
        Assert.Equal(2,player1.GetCards().Count);
    }
    
    [Fact]
    public void LoseStrategy()
    {
        BlackjackPlayer player1 = new BlackjackPlayer(1, 10000);
        Bank bank = new Bank(new BankAccountFactory());
        BlackjackCasino casino = new BlackjackCasino(new CasinoAccountFactory());
        player1.CreateAccount(bank, (uint)21, player1);
        player1.Deposit(bank,(uint)20,player1);
        player1.TakeCard(new Card(Suit.Club,Rank.Two));
        player1.TakeCard(new Card(Suit.Diamond,Rank.Two));
        player1.TakeCard(new Card(Suit.Heart,Rank.Two));
        player1.MakeBet(bank,15);
        List<Card> dealersCards = new List<Card>()
            { new Card(Suit.Heart, Rank.Two), new Card(Suit.Heart, Rank.Three), new Card(Suit.Heart, Rank.Four) };
        player1.Play(11,dealersCards,bank,casino);
        Assert.Equal(26,(int)bank.GetPlayerAccount(1).Balance);
    }

    [Fact]
    public void WinStrategy()
    {
        BlackjackPlayer player1 = new BlackjackPlayer(1, 10000);
        Bank bank = new Bank(new BankAccountFactory());
        BlackjackCasino casino = new BlackjackCasino(new CasinoAccountFactory());
        player1.CreateAccount(bank, (uint)21, player1);
        player1.Deposit(bank,(uint)20,player1);
        player1.TakeCard(new Card(Suit.Club,Rank.Ace));
        player1.TakeCard(new Card(Suit.Diamond,Rank.Nine));
        player1.MakeBet(bank,15);
        List<Card> dealersCards = new List<Card>()
            { new Card(Suit.Heart, Rank.Two), new Card(Suit.Heart, Rank.Three), new Card(Suit.Heart, Rank.Four) };
        player1.Play(11,dealersCards,bank,casino);
        Assert.Equal(56,(int)bank.GetPlayerAccount(1).Balance);
    }
    
    [Fact]
    public void DrawStrategy()
    {
        BlackjackPlayer player1 = new BlackjackPlayer(1, 10000);
        Bank bank = new Bank(new BankAccountFactory());
        BlackjackCasino casino = new BlackjackCasino(new CasinoAccountFactory());
        player1.CreateAccount(bank, (uint)21, player1);
        player1.Deposit(bank,(uint)20,player1);
        player1.TakeCard(new Card(Suit.Club,Rank.Ace));
        player1.TakeCard(new Card(Suit.Diamond,Rank.Ten));
        player1.MakeBet(bank,15);
        List<Card> dealersCards = new List<Card>()
            { new Card(Suit.Club,Rank.Ace), new Card(Suit.Club,Rank.Ten)};
        player1.Play(11,dealersCards,bank,casino);
        Assert.Equal(41,(int)bank.GetPlayerAccount(1).Balance);
    }
}