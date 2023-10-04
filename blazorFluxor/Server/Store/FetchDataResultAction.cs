using Server.Data;

namespace Server.Store;

public sealed class FetchDataResultAction
{
    public IEnumerable<WeatherForecast> Forecasts { get; }

    public FetchDataResultAction(IEnumerable<WeatherForecast> forecasts)
    {
        this.Forecasts = forecasts;
    }
}
