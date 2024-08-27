using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Bank;
using OOP_ICT.Second.Models.Exceptions;
using OOP_ICT.Second.Models.Factories;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestBankFunctions
{
    [Fact]
    public void AreEqual_CorrectPlayerAndBankBalancesWork_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var bank = new Bank(new BankAccountFactory());
        player.CreateAccount(bank, 100, player);
        Assert.Equal((uint)100, bank.GetPlayerAccount(1).Balance);
    }
    
    [Fact]
    public void Throws_AccountsWithSameID_ReturnTrue()
    {
        var player1 = new PlayerAccount(1, 500);
        var player2 = new PlayerAccount(1, 1000);
        var bank = new Bank(new BankAccountFactory());
        player1.CreateAccount(bank, 100, player1);
        Assert.Throws<AccountAlreadyExistsException>(() => player2.CreateAccount(bank, 100, player1));
    }
    
    [Fact]
    public void Throws_InsufficientFunds_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var bank = new Bank(new BankAccountFactory());
        player.CreateAccount(bank, 100, player);
        Assert.Throws<InsufficientFundsException>(() => player.CreateAccount(bank, 1000, player));
    }
    
    [Fact]
    public void AreEqual_WithdrawMoney_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var bank = new Bank(new BankAccountFactory());
        player.CreateAccount(bank, 100, player);
        bank.GetPlayerAccount(1).Withdraw(50);
        Assert.Equal(50.0, (double)bank.GetPlayerAccount(1).Balance);
    }
    
    [Fact]
    public void AreNotEqual_WithdrawMoney_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var bank = new Bank(new BankAccountFactory());
        player.CreateAccount(bank, 100, player);
        bank.GetPlayerAccount(1).Withdraw(50);
        Assert.NotEqual(100.0, (double)bank.GetPlayerAccount(1).Balance);
    }

    [Fact]
    public void AreEqual_DepositFromPlayersBalance_ReturnTrue()
    {
        var player = new PlayerAccount(1, 500);
        var bank = new Bank(new BankAccountFactory());
        player.CreateAccount(bank, 100, player);
        Assert.Equal(400.0, (double)player.Balance);
    }
}