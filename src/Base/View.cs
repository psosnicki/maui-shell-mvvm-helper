using MauiShellMvvmHelper.DI;

namespace MauiShellMvvmHelper.Base;

public class View<TViewModel> : ContentPage where TViewModel: class
{
    public TViewModel Context { get; private set; }
    public View()
    {
        var viewModel = DependencyResolver.Get<TViewModel>();
        Context = viewModel;
        BindingContext = viewModel;
    }
}

