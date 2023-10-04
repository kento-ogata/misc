namespace Server.Store;

public sealed class FetchDataAction
{
    public FetchDataAction(DateOnly date)
    {
        Date = date;
    }

    public DateOnly Date { get; }
}
