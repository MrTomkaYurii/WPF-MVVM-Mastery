using System.Windows;
using DialogServiceShowcase.Services;
using DialogServiceShowcase.ViewModels;

namespace DialogServiceShowcase;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel(new WpfDialogService());
    }
}
