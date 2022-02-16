using Microsoft.Extensions.Logging;

namespace MauiShellSample.ViewModels;

internal class AboutViewModel
{
    private readonly ILogger<AboutViewModel> _logger;

    public string Title { get; set; } = "about view model";

    public AboutViewModel(ILogger<AboutViewModel> logger)
    {
        _logger = logger;
    }
}
