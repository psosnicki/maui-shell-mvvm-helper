# MauiShellMvvmHelper 

Simplifies view - viewmodel registration & binding in .NET MAUI Shell App

# Usage

You can register & bind view - viewmodel in three ways (all examples in samples folder)

 **1) register view and view model directly**
</br>

*MauiProgram.cs*

```
public static MauiApp CreateMauiApp()
{
    var builder = new MauiApp.CreateBuilder();
    ...
    builder.RegisterView<HomePageView, HomeViewModel>();
    ...
    return builder.Build()
}
```

**2) or register view and use ViewModel attribute**
</br>

*MauiProgram.cs*

```
public static MauiApp CreateMauiApp()
{
    var builder = new MauiApp.CreateBuilder();
    ...
    builder.RegisterView<HomePageView>();
    ...
    return builder.Build();
}
```
*HomePageView.cs*

```
[ViewModel(typeof(HomeViewModel))]
public class HomePageView : ContentPage
{
    ...
}
```

**3) or use base view**
</br>

*MauiProgram.cs*
```
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    ...
    builder.Services.AddTransient<DetailsPage>();
    builder.Services.AddTransient<DetailsViewModel>();
    ...
    return builder.Build().UseMvvm();
}
```
*DetailsPage.xaml.cs*
```
public partial class DetailsPage : View<DetailsViewModel>
{
    public DetailsPage()
    {
        InitializeComponent();
    }
}
```
*DetailsPage.xaml*
```
<mvvm:View x:TypeArguments="local:DetailsViewModel" xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MauiShellMvvmExample.DetailsPage"
             xmlns:local="clr-namespace:MauiShellMvvmExample.ViewModels"
             xmlns:mvvm="clr-namespace:MauiShellMvvmHelper.Base;assembly=MauiShellMvvmHelper">
        ...
</mvvm:View>
```