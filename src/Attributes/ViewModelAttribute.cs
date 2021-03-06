namespace MauiShellMvvmHelper.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public  class ViewModelAttribute : Attribute
{
    public Type ViewModelType { get; private set; }

    public ViewModelAttribute(Type viewModel)
    {
        ViewModelType = viewModel;
    }
    protected ViewModelAttribute() { }
}

