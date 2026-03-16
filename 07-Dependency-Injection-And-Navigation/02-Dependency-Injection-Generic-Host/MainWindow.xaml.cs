using System.Windows;
using GenericHostShowcase.ViewModels;
namespace GenericHostShowcase;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
