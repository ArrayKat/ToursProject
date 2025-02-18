using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Client_Tours.ViewModels;

namespace Client_Tours;

public partial class AddChangeHotel : UserControl
{
    public AddChangeHotel()
    {
        InitializeComponent();
        DataContext = new AddChangeHotelVM();
    }
    public AddChangeHotel(int idHotel)
    {
        InitializeComponent();
        DataContext = new AddChangeHotelVM(idHotel);
    }
}