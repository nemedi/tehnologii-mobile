namespace Attendance;

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
		builder.Services.AddSingleton<Services.IAttendanceService, Services.MockAttendanceService>();
		builder.Services.AddTransient<ViewModels.AttendanceListViewModel>();
        builder.Services.AddTransient<Pages.AttendanceListPage>();
        builder.Services.AddTransient<ViewModels.AttendanceViewModel>();
        builder.Services.AddTransient<Pages.AttendancePage>();
        return builder.Build();
	}
}
