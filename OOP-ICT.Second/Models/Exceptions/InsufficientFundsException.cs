namespace OOP_ICT.Second.Models.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base() { }
    public InsufficientFundsException(string message) : base(message) { }
    public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
}