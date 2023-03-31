using Microsoft.Extensions.Logging;

namespace Essentials;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
#if WINDOWS
				essentials.UseMapServiceToken("RJHqIE53Onrqons5CNOx~FrDr3XhjDTyEXEjng-CRoA~Aj69MhNManYUKxo6QcwZ0wmXBtyva0zwuHB04rFYAPf7qqGJ5cHb03RCDw1jIW8l");
#endif
                essentials.AddAppAction("app_info", "App Info", icon: "app_info_action_icon");
                essentials.AddAppAction("battery_info", "Battery Info");
                essentials.OnAppAction(App.HandleAppActions);
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
