namespace OOP_ICT.Second.Models.Exceptions;

public class AccountAlreadyExistsException : Exception
{
    public AccountAlreadyExistsException() : base() { }
    public AccountAlreadyExistsException(string message) : base(message) { }
    public AccountAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}