using HollysPillReminderApp.Interfaces;
using HollysPillReminderApp.View;
using HollysPillReminderApp.ViewModel;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using HollysPillReminderApp;
using ForegroundService = HollysPillReminderApp;

namespace HollysPillReminderApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseLocalNotification()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddTransient<TimeSelectView>();
		builder.Services.AddTransient<TimeSelectViewModel>();

#if ANDROID
		builder.Services.AddTransient<IServices, ForegroundService>();
#endif

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
