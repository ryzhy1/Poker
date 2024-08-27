using OOP_ICT.First.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.Bank;
using OOP_ICT.Second.Models.Casino;

namespace OOP_ICT.Second;

public class GameLogic
{
    public int Play(int pointsForAce, List<Card> dealersCards, Bank bank,
        BlackjackCasino casino, BlackjackPlayer _player, int _bet)
    {
        int blackjackPoints = 21;
        int totalPlayerPoints = 0;
        foreach (var card in _player.GetCards())
        {
            totalPlayerPoints += OOP_ICT.Third.Convert.ConvertPoints(card.Rank.ToString(), pointsForAce);
        }

        int totalDealerPoints = 0;
        foreach (var card in dealersCards)
        {
            totalDealerPoints += OOP_ICT.Third.Convert.ConvertPoints(card.Rank.ToString(), pointsForAce);
        }

        if (totalDealerPoints > blackjackPoints)
        {
            bank.GetPlayerAccount(_player.Id).Deposit((uint)_bet * 2);
            _bet = 0;
            return 0;
        }

        if (((blackjackPoints - totalPlayerPoints) < (blackjackPoints - totalDealerPoints)) &&
            (blackjackPoints - totalPlayerPoints) > 0)
        {
            bank.GetPlayerAccount(_player.Id).Deposit((uint)_bet * 2);
            _bet = 0;
            return 0;
        }

        if (totalPlayerPoints == blackjackPoints && totalDealerPoints < blackjackPoints)
        {
            bank.GetPlayerAccount(_player.Id).Deposit((uint)_bet * 2);
            _bet = 0;
            return 0;
        }
        
        if (totalPlayerPoints == blackjackPoints && totalDealerPoints == blackjackPoints)
        {
            bank.GetPlayerAccount(_player.Id).Deposit((uint)_bet);
            _bet = 0;
        }

        return _bet;
    }

}

  