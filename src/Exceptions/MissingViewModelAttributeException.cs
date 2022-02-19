namespace MauiShellMvvmHelper.Exceptions;

public class MissingViewModelAttributeException : Exception
{
    public MissingViewModelAttributeException(Type viewType)
        : base($"Unable to find ViewModel attribute on {viewType.Name} view. Please add ViewModelAttribute or use Register<TView, KViewModel> method)") { }
}

