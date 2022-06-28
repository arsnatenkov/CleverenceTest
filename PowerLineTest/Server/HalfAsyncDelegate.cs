namespace Server;

public class HalfAsyncDelegate
{
    private EventHandler _eventHandler;

    public HalfAsyncDelegate(EventHandler eventHandler)
    {
        _eventHandler = eventHandler;
    }

    public bool Invoke(int milliseconds, object sender, EventArgs args)
    {
        Task task = Task.Factory.StartNew(() => _eventHandler.Invoke(sender, args));

        return task.Wait(milliseconds);
    }
    
    
}