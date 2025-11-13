using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Networking;

namespace Matrimony.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton<IConnectivity>(_ => Connectivity.Current);
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<Views.HomePage>();
        builder.Services.AddSingleton<Views.ProfilePage>();
        builder.Services.AddSingleton<ViewModels.HomeViewModel>();
        builder.Services.AddSingleton<ViewModels.ProfileViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
