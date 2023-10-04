using Server.Store;
using Server.Store.CounterUseCase;

namespace Server.Pages;

public sealed partial class Counter : FluxorComponent
{
    [Inject]
    private IState<CounterState> CounterState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    private void IncrementCount()
    {
        var action = new IncrementCounterAction();
        Dispatcher.Dispatch(action);
    }
}
