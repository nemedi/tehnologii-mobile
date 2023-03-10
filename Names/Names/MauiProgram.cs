using Microsoft.Extensions.Logging;

namespace Names;

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
		builder.Services.AddTransient<ViewModels.ISearchNameViewModel, ViewModels.SearchNameViewModel>();
		builder.Services.AddTransient<Views.SearchNamePage>();
		return builder.Build();
	}
}
