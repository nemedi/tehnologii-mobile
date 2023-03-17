using Microsoft.Extensions.Logging;

namespace FlightRadar;

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
		builder.Services.AddSingleton<Services.IFlightsService, Services.FlightsService>();
        builder.Services.AddTransient<ViewModels.IFlightRadarViewModel, ViewModels.FlightViewModel>();
		builder.Services.AddTransient<Pages.FlightsRadarPage>();
        return builder.Build();
	}
}
