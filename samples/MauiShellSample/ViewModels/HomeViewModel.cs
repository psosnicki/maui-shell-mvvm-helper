using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace MauiShellMvvmExample.ViewModels
{
    public class HomeViewModel
    {
        public string Test { get; set; } = "Home view model";
        public ICommand ChangeMessageCmd { get; set; }
        private readonly ILogger<HomeViewModel> _logger;


        public HomeViewModel(ILogger<HomeViewModel> logger)
        {
            _logger = logger;
            ChangeMessageCmd = new Command(async () => {
                await Shell.Current.GoToAsync($"{nameof(DetailsPage)}");
            });
    
        }
    }
}
