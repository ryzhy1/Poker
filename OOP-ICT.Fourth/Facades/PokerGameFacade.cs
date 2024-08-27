using OOP_ICT.First.Models;

namespace OOP_ICT.Fourth;

public class PokerGameFacade
{
    private List<PokerPlayer> _pokerPlayers;
    private int _totalBet;
    private PokerCasino _pokerCasino;

    public PokerGameFacade(PokerCasino pokerCasino, List<PokerPlayer> pokerPlayers, int totalBet)
    {
        _pokerPlayers = pokerPlayers;
        _totalBet = totalBet;
        _pokerCasino = pokerCasino;
    }

    public void StartGame(PokerCasino casino, Dealer dealer, uint firstBlindAmount, uint secondBlindAmount, Table table)
    {
        foreach (var player in _pokerPlayers)
        {
            player.TakeCard(dealer.GiveCardDirectly());
            player.TakeCard(dealer.GiveCardDirectly());
        }

        table.PutCardOnTable(dealer.GiveCardDirectly());
        table.PutCardOnTable(dealer.GiveCardDirectly());
        table.PutCardOnTable(dealer.GiveCardDirectly());
        
        _pokerPlayers[0].MakeBet(_pokerCasino, _pokerPlayers[0], firstBlindAmount);
        _totalBet += (int)firstBlindAmount;
        _pokerPlayers[1].MakeBet(_pokerCasino, _pokerPlayers[1], secondBlindAmount);
        _totalBet += (int)secondBlindAmount;
    }

    public PokerPlayer GetWinner(Table table)
    {
        int maxPoints = 0;
        PokerPlayer winner = _pokerPlayers[0];
        foreach (var player in _pokerPlayers)
        {
            if (player.GetBestCombination(table.Cards) > maxPoints)
            {
                maxPoints = player.GetBestCombination(table.Cards);
                winner = player;
                
            }
        }
        
        return winner;
    }
    
    public void GiveMoneyToWinner(PokerPlayer winner, PokerCasino casino)
    {
        casino.Deposit(winner, (uint)_totalBet);
    }
}
