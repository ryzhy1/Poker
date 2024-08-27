namespace OOP_ICT.First.Models;

public interface IPlayer
{
    void AddCardToHand(Card card);
    public IEnumerable<Card> ShowCards();
}