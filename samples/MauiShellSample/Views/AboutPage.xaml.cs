using MauiShellMvvmHelper.Attributes;
using MauiShellSample.ViewModels;

namespace MauiShellMvvmExample;

[ViewModel(typeof(AboutViewModel))]
public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
}