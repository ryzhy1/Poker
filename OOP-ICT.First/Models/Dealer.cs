using System.Collections.Generic;

namespace OOP_ICT.First.Models;

public class Dealer : IDealer
{
    private CardDeck _deck { get; set; }

    public Dealer()
    {
        _deck = new CardDeck();
    }
    
    public void ShuffleCards(IAlgorithm shuffle)
    {
        _deck = new CardDeck(shuffle.ShuffleAlgorithm(_deck.Deck));
    }
    
    public void GiveCards(List<IPlayer> players, int amountOfCardsToGive)
    {
        if (_deck.Deck.Count < players.Count * amountOfCardsToGive)
        {
            throw new NotEnoughCardsException("В колоде недостаточно карт");
        }

        for (int i = 0; i < amountOfCardsToGive; i++)
        {
            foreach (var player in players)
            {
                var card = TakeCardAlgorithm();
                player.AddCardToHand(card);
            }
        }
    }

    public Card TakeCardAlgorithm()
    {
        var card = _deck.GiveCard();
        return card;
    }

    public Card GiveCardDirectly()
    {
        return _deck.GiveCard();
    }

}