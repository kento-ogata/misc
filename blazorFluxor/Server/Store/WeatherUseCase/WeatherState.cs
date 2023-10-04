using Server.Data;

namespace Server.Store.WeatherUseCase;

[FeatureState]
public sealed class WeatherState
{
    public bool IsLoading { get; }
    public IEnumerable<WeatherForecast>? Forecasts { get; }

    private WeatherState() {}

    public WeatherState(bool isLoading, IEnumerable<WeatherForecast>? forecasts)
    {
        IsLoading = isLoading;
        Forecasts = forecasts;
    }
}
