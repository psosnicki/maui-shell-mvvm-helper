namespace MauiShellMvvmHelper.DI;

public static class DependencyResolver
{
    private static IServiceProvider _serviceProvider;
    public static T Get<T>()=> _serviceProvider.GetRequiredService<T>();
    public static void Setup(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}

