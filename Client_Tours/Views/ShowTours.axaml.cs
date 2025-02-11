using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Client_Tours.ViewModels;
using System.Threading.Tasks;


namespace Client_Tours;

public partial class ShowTours : UserControl
{
    public ShowTours()
    {
        InitializeComponent();
        DataContext = new ShowToursVM();
    }

    
    
}