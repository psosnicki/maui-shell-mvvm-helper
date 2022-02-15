using MauiShellMvvmHelper.DI;

namespace MauiShellMvvmHelper.Base;

public class View<T> : ContentPage where T : class
{
    public T Context { get; private set; }
    public View() : base()
    {
        var viewModel = DependencyResolver.Get<T>();
        Context = viewModel;
        BindingContext = viewModel;
    }
}

