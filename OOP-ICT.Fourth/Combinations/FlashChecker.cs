using OOP_ICT.First.Models;

using OOP_ICT.Fourth.Combinations;

public class FlashChecker : Chain
{
    public override PokerCombination GetChainResult(List<Card> cards)
    {
        Dictionary<string, int> suitCounter = new Dictionary<string, int>() { { "Clubs", 0 }, { "Diamonds", 0 }, { "Hearts", 0 }, { "Spades", 0 } };
        foreach (var card in cards)
        {
            suitCounter[card.Suit.ToString()]++;
        }

        if (suitCounter["Clubs"] >= 5 || suitCounter["Diamonds"] >= 5 || suitCounter["Hearts"] >= 5 ||
            suitCounter["Spades"] >= 5)
        {
            return PokerCombination.Flush;
        }
        return 0;
    }
}