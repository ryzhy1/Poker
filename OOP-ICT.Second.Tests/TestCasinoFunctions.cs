using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Exceptions;
using OOP_ICT.Second.Models.Factories;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCasinoFunctions
{
    [Fact]
    public void AreEqual_CorrectPlayerAndCasinoBalancesWork_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var casino = new BlackjackCasino(new CasinoAccountFactory());
        player.CreateAccount(casino, 100, player);
        Assert.Equal((uint)100, casino.GetPlayerAccount(1).Bitcoins);
    }
    
    [Fact]
    public void Throws_AccountsWithSameID_ReturnTrue()
    {
        var player1 = new PlayerAccount(1, 500);
        var player2 = new PlayerAccount(2, 1000);
        var casino = new BlackjackCasino(new CasinoAccountFactory());
        player1.CreateAccount(casino, 100, player1);
        Assert.Throws<AccountAlreadyExistsException>(() => player2.CreateAccount(casino, 100, player1));
    }
    
    [Fact]
    public void Throws_InsufficientFunds_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var casino = new BlackjackCasino(new CasinoAccountFactory());
        player.CreateAccount(casino, 100, player);
        Assert.Throws<InsufficientFundsException>(() => player.CreateAccount(casino, 1000, player));
    }
    
    [Fact]
    public void AreEqual_WithdrawMoney_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var casino = new BlackjackCasino(new CasinoAccountFactory());
        player.CreateAccount(casino, 100, player);
        casino.GetPlayerAccount(1).Withdraw(50);
        Assert.Equal((uint)50, casino.GetPlayerAccount(1).Bitcoins);
    }
    
    [Fact]
    public void AreNotEqual_WithdrawMoney_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var casino = new BlackjackCasino(new CasinoAccountFactory());
        player.CreateAccount(casino, 100, player);
        casino.GetPlayerAccount(1).Withdraw(50);
        Assert.NotEqual((uint)100, casino.GetPlayerAccount(1).Bitcoins);
    }

    [Fact]
    public void AreEqual_DepositFromPlayersBalance_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var casino = new BlackjackCasino(new CasinoAccountFactory());
        player.CreateAccount(casino, 100, player);
        Assert.Equal(400.0, (double)player.Balance);
    }
}