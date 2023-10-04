using Server.Data;

namespace Server.Store.WeatherUseCase;

public sealed class Effects
{
    private readonly WeatherForecastService _weatherForecastService;

    public Effects(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
    {
        var forecasts = await _weatherForecastService.GetForecastAsync(action.Date);
        dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
}
