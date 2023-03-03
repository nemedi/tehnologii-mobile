using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Internals;

namespace CoinsCatalog;

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
		builder.Services.AddSingleton<Data.IRepository, Data.DatabaseRepository>();
		builder.Services.AddSingleton<Services.IDataService, Services.DataService>();
		builder.Services.AddTransient<ViewModels.IIssuersViewModel, ViewModels.IssuersViewModel>();
        builder.Services.AddTransient<ViewModels.ICoinsByIssuerViewModel, ViewModels.CoinsByIssuerViewModel>();
        builder.Services.AddTransient<Views.IssuersPage>();
        builder.Services.AddTransient<ViewModels.CoinsByIssuerViewModel>();
        builder.Services.AddTransient<Views.CoinsByIssuerPage>();
        return builder.Build();
	}
}
