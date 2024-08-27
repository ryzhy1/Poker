namespace OOP_ICT.First.Models;

public class NotEnoughCardsException : Exception
{
    public NotEnoughCardsException(string message) : base(message)
    {
    }
}   
