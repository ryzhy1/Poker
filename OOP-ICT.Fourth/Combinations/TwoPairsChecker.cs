using OOP_ICT.First.Models;
using OOP_ICT.Fourth.Combinations;

public class TwoPairsChecker : Chain
{
    public override PokerCombination GetChainResult(List<Card> cards)
    {
        List<int> ranks = new List<int>(){ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int count = 0;
        foreach (var card in cards)
        {
            ranks[Converter.Convert(card.Rank.ToString())]++;
        }

        foreach (var variable in ranks)
        {
            if (variable >= 2)
            {
                count++;
            }
        }

        if (count >= 2)
        {
            return PokerCombination.TwoPairs;
        }
        
        return 0;
    }
}