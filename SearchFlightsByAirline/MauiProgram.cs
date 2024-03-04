using Microsoft.Extensions.Logging;

namespace SearchFlightsByAirline
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<Services.IFlightService, Services.FlightService>();
            builder.Services.AddTransient<ViewModels.IFlightsViewModel, ViewModels.FlightsViewModel>();
            builder.Services.AddTransient<Views.FlightsPage>();
            return builder.Build();
        }
    }
}
