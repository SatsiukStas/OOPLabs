using Acr.UserDialogs;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using kursach.Services;
using kursach.ViewModels;
using kursach.Views;

namespace kursach;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddTransient<MenuShell>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<RegisterPageView>();
        builder.Services.AddTransient<ProfileView>();
        builder.Services.AddTransient<BasketView>();
        builder.Services.AddTransient<MainMenu>();
        builder.Services.AddTransient<EditToursView>();
        builder.Services.AddTransient<SettingTourView>();
        builder.Services.AddTransient<DetailTourView>();
        builder.Services.AddTransient<CreateVacancyView>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<MainMenuViewModel>();
        builder.Services.AddTransient<BasketViewModel>();
        builder.Services.AddTransient<SettingTourViewModel>();
        builder.Services.AddTransient<DetailTourViewModel>();
        builder.Services.AddTransient<EditToursViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<CreateVacancyViewModel>();

        builder.Services.AddSingleton<DatabaseService>();
        return builder.Build();
	}
}
