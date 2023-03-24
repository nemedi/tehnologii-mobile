using Microsoft.Extensions.Logging;

namespace Coins;

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
		builder.Services.AddSingleton<Data.Database>();
        builder.Services.AddTransient<ViewModels.CountriesViewModel>();
        builder.Services.AddTransient<Pages.CountriesPage>();
        builder.Services.AddTransient<ViewModels.CoinsByCountryViewModel>();
        builder.Services.AddTransient<Pages.CoinsByCountryPage>();
        builder.Services.AddTransient<ViewModels.CoinViewModel>();
        builder.Services.AddTransient<Pages.CoinPage>();
        builder.Services.AddTransient<ViewModels.CoinPhotosViewModel>();
        builder.Services.AddTransient<Pages.CoinPhotosPage>();
        return builder.Build();
	}
}
