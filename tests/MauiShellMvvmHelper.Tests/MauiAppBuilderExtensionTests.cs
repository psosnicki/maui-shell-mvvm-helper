using Xunit;
using MauiShellMvvmHelper.Extensions;
using Microsoft.Maui.Hosting;
using MauiShellMvvmHelper.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using MauiShellMvvmHelper.Attributes;
using Microsoft.Maui.Controls;

namespace MauiShellMvvmHelper.Tests;

public class MauiAppBuilderExtensionTests
{
    private readonly MauiAppBuilder _mauiAppBuilder;

    public MauiAppBuilderExtensionTests()
    {
        _mauiAppBuilder = MauiApp.CreateBuilder();
    }

    [Fact]
    public void Should_Throw_Missing_View_Model_Exception_When_View_Model_Attribute_Not_Found()
        => Should.Throw<MissingViewModelAttributeException>(() => _mauiAppBuilder.RegisterView<NoAttributeView>());
        
    [Fact]
    public void Should_Register_And_Bind_View_Model()
    {
        _mauiAppBuilder.RegisterView<TestView,TestViewModel>();
        var mauiApp = _mauiAppBuilder.Build();
        var view = mauiApp.Services.GetRequiredService<TestView>();
        view.ShouldNotBeNull()
            .BindingContext
            .ShouldNotBeNull()
            .ShouldBeOfType<TestViewModel>();
    }

    [Fact]
    public void Should_Register_And_Bind_View_Model_Based_On_ViewModel_Attribute()
    {
        _mauiAppBuilder.RegisterView<AttributeView>();
        var mauiApp = _mauiAppBuilder.Build();
        var view = mauiApp.Services.GetRequiredService<AttributeView>();
        view.ShouldNotBeNull()
            .BindingContext
            .ShouldNotBeNull()
            .ShouldBeOfType<TestViewModel>();
    }
}



[ViewModel(typeof(TestViewModel))]
internal class AttributeView : BindableObject { }
internal class TestView : BindableObject { }
internal class TestViewModel { }
internal class NoAttributeView : BindableObject { }