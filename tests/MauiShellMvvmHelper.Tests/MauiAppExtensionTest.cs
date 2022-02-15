using Xunit;
using MauiShellMvvmHelper.Extensions;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using MauiShellMvvmHelper.Base;

namespace MauiShellMvvmHelper.Tests;

public class MauiAppExtensionTests
{
    private readonly MauiAppBuilder _mauiAppBuilder;

    public MauiAppExtensionTests()
    {
        _mauiAppBuilder = MauiApp.CreateBuilder();
    }

    [Fact]
    public void Should_Set_Binding_Context_When_Using_BaseView()
    {
        _mauiAppBuilder.Services
            .AddTransient<TestBaseView>()
            .AddTransient<TestViewModel>();

        var app = _mauiAppBuilder.Build().UseMvvm();
        var view = app.Services.GetRequiredService<TestBaseView>();
        view.Context
            .ShouldNotBeNull()
            .ShouldBeOfType<TestViewModel>();
        view.BindingContext
            .ShouldNotBeNull()
            .ShouldBeSameAs(view.Context);
    }
}

internal class TestBaseView : View<TestViewModel> { }