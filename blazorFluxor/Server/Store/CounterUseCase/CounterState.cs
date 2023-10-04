namespace Server.Store.CounterUseCase;

[FeatureState]
public sealed class CounterState
{
    public int ClickCount { get; }

    private CounterState() {}

    public CounterState(int clickCount)
    {
        ClickCount = clickCount;
    }
}
