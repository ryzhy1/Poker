using System.Collections.Generic;

namespace OOP_ICT.First.Models;

public class PerfectShuffleAlgorithm : IAlgorithm
{
    private List<Card> shuffledCards;
    
    public List<Card> ShuffleAlgorithm(IReadOnlyList<Card> CardsArr)
    {
        int n = CardsArr.Count;
        int half = n / 2;

        var shaffledCards = new List<Card>(new Card[n]);

        for (int i = 0; i < half; i++)
        {
            shaffledCards[i*2] = CardsArr[i + half];
            shaffledCards[i*2+1] = CardsArr[i];
        }

        return shaffledCards;
    }
}