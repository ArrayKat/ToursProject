using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Client_Tours.ViewModels;

namespace Client_Tours;

public partial class ShowHotels : UserControl
{
    public ShowHotels()
    {
        InitializeComponent();
        DataContext = new ShowHotelsVM();
    }
}