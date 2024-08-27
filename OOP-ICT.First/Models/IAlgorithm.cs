using System.Collections.Generic;

namespace OOP_ICT.First.Models;

public interface IAlgorithm
{
    public List<Card> ShuffleAlgorithm(IReadOnlyList<Card> cardsArr);
}