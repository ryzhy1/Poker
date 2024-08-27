using OOP_ICT.First.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Casino;
using OOP_ICT.Second.Models.Exceptions;
using OOP_ICT.Second.Models.Factories;
using OOP_ICT.Second.Models.Interfaces;
using Player = OOP_ICT.First.Models.Player;

namespace OOP_ICT.Fourth;

public class PokerCasino : IPayment
{
    private readonly Dictionary<int, CasinoAccount> _casinoAccounts;

    private readonly CasinoAccountFactory _casinoAccountFactory;

    public PokerCasino(CasinoAccountFactory casinoAccountFactory)
    {
        _casinoAccounts = new Dictionary<int, CasinoAccount>();
        _casinoAccountFactory = casinoAccountFactory;
    }
    
    public void CreateAccount(Player player, uint money)
    {
        if (money > player.Balance)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        
        if (_casinoAccounts.ContainsKey(player.Id))
        {
            throw new AccountAlreadyExistsException("The account already exists");
        }
        _casinoAccounts.Add(player.Id, _casinoAccountFactory.CreateAccount(player.Id, money));
    }

    public void Deposit(Player player, uint money)
    {
        if (money > player.Balance)
        {
            throw new InsufficientFundsException("Insufficient funds in the account");
        }
        
        if (!_casinoAccounts.ContainsKey(player.Id))
        {
            throw new AccountDoesNotExistException("Account not found");
        }
        _casinoAccounts[player.Id].Deposit(money);
    }

    public void Withdraw(Player player, uint money)
    {
        if (!_casinoAccounts.ContainsKey(player.Id))
        {
            throw new AccountDoesNotExistException("Account not found");
        } 
        _casinoAccounts[player.Id].Withdraw(money);
    }

    public void PlayerGotBlackjack(PlayerAccount player, uint money)
    {
        Deposit(player, money * 2);
    }
    
    public CasinoAccount GetPlayerAccount(int Id)
    {
        if (!_casinoAccounts.ContainsKey(Id))
        {
            throw new AccountDoesNotExistException("Account not found");
        }
        return _casinoAccounts[Id];
    }
}