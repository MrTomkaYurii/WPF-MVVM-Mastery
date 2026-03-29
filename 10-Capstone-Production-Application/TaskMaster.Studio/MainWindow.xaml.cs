using System.Windows;
using TaskMaster.Studio.ViewModels;

namespace TaskMaster.Studio;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
