namespace OOP_ICT.Second.Models.Exceptions;

public class AccountDoesNotExistException : Exception
{
    public AccountDoesNotExistException() : base() { }
    public AccountDoesNotExistException(string message) : base(message) { }
    public AccountDoesNotExistException(string message, Exception inner) : base(message, inner) { }
}