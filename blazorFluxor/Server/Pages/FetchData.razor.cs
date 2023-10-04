using Server.Store;
using Server.Store.WeatherUseCase;

namespace Server.Pages;

public sealed partial class FetchData : FluxorComponent
{
    [Inject]
    private IState<WeatherState> WeatherState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Dispatcher.Dispatch(new FetchDataAction(DateOnly.FromDateTime(DateTime.Today)));
    }
}
