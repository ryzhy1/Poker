using OOP_ICT.First.Models;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class Table
{
    public List<Card> Cards { get; private set;}

    public Table()
    {
        Cards = new List<Card>();
    }

    public void PutCardOnTable(Card card)
    {
        Cards.Add(card);
    }
}