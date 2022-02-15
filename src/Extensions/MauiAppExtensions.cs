
using MauiShellMvvmHelper.DI;

namespace MauiShellMvvmHelper.Extensions;

public static class MauiAppExtensions
{
    public static MauiApp UseMvvm(this MauiApp mauiApp)
    {
        DependencyResolver.Setup(mauiApp.Services);
        return mauiApp;
    }
}
