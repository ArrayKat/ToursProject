using Avalonia.Controls;
using Client_Tours.Models;
using ReactiveUI;

namespace Client_Tours.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        

        public static MainWindowViewModel Instance;

        UserControl _pageContent;

        public UserControl PageContent { get => _pageContent; set => this.RaiseAndSetIfChanged(ref _pageContent, value); }
        public MainWindowViewModel() {
            Instance = this;
            PageContent = new ShowTours();
        }

        public ApiConection api = new ApiConection();
    }
}
