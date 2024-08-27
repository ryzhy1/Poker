namespace OOP_ICT.First.Models;

public class CardDeck
{
    private List<Card> _deck { get; set; }

    private List<Card> InitDeck()
    {
        return _deck = Enum.GetValues(typeof(Suit))
            .Cast<Suit>()
            .SelectMany(suit => Enum.GetValues(typeof(Rank))
                .Cast<Rank>()
                .Select(rank => new Card(suit, rank)))
            .ToList();
    }
    public CardDeck()
    {
        _deck = InitDeck();
    }
    
    public CardDeck(List<Card> deck)
    {
        _deck = deck;
    }

    public IReadOnlyList<Card> Deck => _deck;

    public Card GiveCard()
    {
        var card = _deck.Last();
        _deck = _deck.Take(_deck.Count - 1).ToList();
        return card;
    }
}