namespace Server;

public static class Server
{
    private static int _count;

    private static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();

    public static int GetCount()
    {
        readerWriterLockSlim.EnterReadLock();
        try
        {
            return _count;
        }
        finally
        {
            readerWriterLockSlim.ExitReadLock();
        }
    }

    public static void AddToCount(int value)
    {
        readerWriterLockSlim.EnterWriteLock();
        try
        {
            checked
            {
                _count += value;
            }
        }
        finally
        {
            readerWriterLockSlim.ExitWriteLock();
        }
    }
}