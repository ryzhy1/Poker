using System.Collections.Generic;


namespace OOP_ICT.First.Models;


public class Player : IPlayer
{
    public readonly int Id;

    public uint Balance { get; private set; }
    
    private List<Card> _hand { get; }
    
    public Player(int id, uint balance)
    {
        Id = id;
        Balance = balance;
        _hand = new List<Card>();
    }

    public void AddCardToHand(Card card)
    {
        _hand.Add(card);
    }
    
    public IEnumerable<Card> ShowCards()
    {
        return _hand.AsReadOnly();
    }
}