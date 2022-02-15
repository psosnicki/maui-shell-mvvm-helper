using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiShellMvvmExample.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand ChangeMessageCmd { get; set; }

        private string _test;
        private readonly ILogger<HomeViewModel> _logger;

        public string Test { get => _test; set {
                _test = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
            } 
        }

        public HomeViewModel(ILogger<HomeViewModel> logger)
        {
            _logger = logger;
            Test = "Home view model";
            ChangeMessageCmd = new Command(async () => {
                await Shell.Current.GoToAsync($"{nameof(DetailsPage)}");
            });
    
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
