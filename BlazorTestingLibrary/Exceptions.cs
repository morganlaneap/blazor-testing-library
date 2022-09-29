namespace BlazorTestingLibrary;

public class ActionTimedOutException : Exception
{
    public ActionTimedOutException(string? message) : base(message)
    {
        
    }
}