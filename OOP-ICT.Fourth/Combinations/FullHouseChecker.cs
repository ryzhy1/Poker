using OOP_ICT.First.Models;
using OOP_ICT.Fourth.Combinations;

public class FullHouseChecker : Chain
{
    public override PokerCombination GetChainResult(List<Card> cards)
    {
        List<int> ranks = new List<int>(){ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int countTwo = 0;
        int countThree = 0;
        foreach (var card in cards)
        {
            ranks[Converter.Convert(card.Rank.ToString())]++;
        }

        foreach (var variable in ranks)
        {
            if (variable >= 2)
            {
                countTwo++;
            }

            if (variable >= 3)
            {
                countThree++;
            }
        }

        if (countTwo > 0 && countThree > 0)
        {
            return PokerCombination.FullHouse;
        }
        
        return 0;
    }
}