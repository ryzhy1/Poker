using OOP_ICT.First.Models;

using OOP_ICT.Fourth.Combinations;

public class PairChecker : Chain
{
    public override PokerCombination GetChainResult(List<Card> cards)
    {
        List<int> ranks = new List<int>(){ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        foreach (var card in cards)
        {
            ranks[Converter.Convert(card.Rank.ToString())]++;
        }

        foreach (var variable in ranks)
        {
            if (variable >= 2)
            {
                return PokerCombination.OnePair;
            }
        }
        
        return 0;
    }
}