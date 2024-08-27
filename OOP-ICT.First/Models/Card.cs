namespace OOP_ICT.First.Models;

public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }
    
    public Card(Suit suit, Rank rank) {
        Suit = suit;
        Rank = rank;
    }
}