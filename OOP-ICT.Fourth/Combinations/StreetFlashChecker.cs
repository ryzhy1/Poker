using OOP_ICT.First.Models;
using OOP_ICT.Fourth.Combinations;

public class StreetFlashChecker : Chain
{
    public override PokerCombination GetChainResult(List<Card> cards)
    {
        List<string> ranks = new List<string>()
            { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "King", "Queen", "Jack", "Ace" };
        Dictionary<string, List<string>> all = new Dictionary<string, List<string>>()
        {
            { "Two", new List<string>() },
            { "Three", new List<string>() },
            { "Four", new List<string>() },
            { "Five", new List<string>() },
            { "Six", new List<string>() },
            { "Seven", new List<string>() },
            { "Eight", new List<string>() },
            { "Nine", new List<string>() },
            { "Ten", new List<string>() },
            { "King", new List<string>() },
            { "Queen",new List<string>() },
            { "Jack",new List<string>() },
            { "Ace",new List<string>() }
        };
        
        int sequence = 0;
        foreach (var card in cards)
        {
            all[card.Rank.ToString()].Add(card.Suit.ToString());
        }
        
        for (int i = 0; i < ranks.Count; i++)
        {
            if ((sequence == 4 && all[ranks[i]].Count != 0) && 
                ((all[ranks[i-1]].Contains("Clubs") && all[ranks[i]].Contains("Clubs")) || 
                 (all[ranks[i-1]].Contains("Hearts") && all[ranks[i]].Contains("Hearts")) ||
                 (all[ranks[i-1]].Contains("Spades") && all[ranks[i]].Contains("Spades")) ||
                 (all[ranks[i-1]].Contains("Diamonds") && all[ranks[i]].Contains("Diamonds"))))
            {
                sequence++;
                break;
            }
            
            if ((all[ranks[i]].Count != 0 && all[ranks[i + 1]].Count != 0) && 
                ((all[ranks[i+1]].Contains("Clubs") && all[ranks[i]].Contains("Clubs")) || 
                    (all[ranks[i+1]].Contains("Hearts") && all[ranks[i]].Contains("Hearts")) ||
                    (all[ranks[i+1]].Contains("Spades") && all[ranks[i]].Contains("Spades")) ||
                    (all[ranks[i+1]].Contains("Diamonds") && all[ranks[i]].Contains("Diamonds"))))
            {
                sequence++;
            }
            else
            {
                sequence = 0;
            }
        }

        if (sequence == 5)
        {
            return PokerCombination.StraightFlush;
        }
        
        return 0;
    }
}