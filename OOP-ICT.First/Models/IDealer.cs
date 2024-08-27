using System.Collections.Generic;

namespace OOP_ICT.First.Models;

public interface IDealer
{
    void ShuffleCards(IAlgorithm shuffle);
    void GiveCards(List<IPlayer> player, int numberOfCards);
}