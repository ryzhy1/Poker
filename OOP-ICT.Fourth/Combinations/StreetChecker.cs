using OOP_ICT.First.Models;
using OOP_ICT.Fourth.Combinations;

public class StreetChecker : Chain
{
    public override PokerCombination GetChainResult(List<Card> cards)
    {
        List<int> ranks = new List<int>(){ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int sequence = 0;
        foreach (var card in cards)
        {
            ranks[Converter.Convert(card.Rank.ToString())]++;
        }

        for (int i = 3; i < ranks.Count; i++)
        {
            if (sequence == 4 && ranks[i-1] > 0)
            {
                sequence++;
                break;
            }
            if (ranks[i] != 0 && ranks[i - 1] != 0)
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
            return PokerCombination.Straight;
        }
        return 0;
    }
}