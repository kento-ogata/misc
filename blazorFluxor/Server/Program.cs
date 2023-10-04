using System.Reflection;
using Server.Data;
using Server.Store.Middlewares.Logging;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
void ConfigureService(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<WeatherForecastService>();
    services.AddFluxor(opts =>
        opts
            .ScanAssemblies(Assembly.GetExecutingAssembly())
            .AddMiddleware<LoggingMiddleware>()
        #if DEBUG
            .UseReduxDevTools(rdt =>
            {
                rdt.UseNewtonsoftJson(_ =>
                    new()
                    {
                        ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
                        {
                            NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy(),
                        }
                    }
                );
            })
        #endif
    );
};

ConfigureService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
