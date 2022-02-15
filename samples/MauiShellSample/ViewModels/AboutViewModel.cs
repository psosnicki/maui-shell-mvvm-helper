using Microsoft.Extensions.Logging;

namespace MauiShellSample.ViewModels;

internal class AboutViewModel
{
    private readonly ILogger<AboutViewModel> _logger;

    public AboutViewModel(ILogger<AboutViewModel> logger)
    {
        _logger = logger;
    }
}
