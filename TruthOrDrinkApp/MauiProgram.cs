using Core.Interfaces;
using Core.Services;
using TruthOrDrinkApp.ViewModels;
using TruthOrDrinkApp.Views;

namespace TruthOrDrinkApp;

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

        // Services (Core)
        builder.Services.AddSingleton<IAuthService, MockAuthService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();

        // Views
        builder.Services.AddTransient<LoginPage>();

        return builder.Build();
    }
}
