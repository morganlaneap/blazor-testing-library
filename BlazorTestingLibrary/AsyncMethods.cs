namespace BlazorTestingLibrary;

public static class AsyncMethods
{
    public static async Task WaitFor(Action action, int timeout = 5000)
    {
        var end = DateTime.Now.AddMilliseconds(timeout).Ticks;
        while (DateTime.Now.Ticks < end)
        {
            try
            {
                await Task.Run(action);
                return;
            }
            catch
            {
                // do nothing 
            }
        }

        throw new ActionTimedOutException("The given action was not successful within the timeout.");
    }
}