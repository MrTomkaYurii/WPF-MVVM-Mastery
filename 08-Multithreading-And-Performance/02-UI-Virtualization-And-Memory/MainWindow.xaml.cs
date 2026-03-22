using System.Windows;

namespace VirtualizationShowcase;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var data = Enumerable.Range(1, 50000).Select(i => $"Virtual Item #{i:N0} — High Performance WPF Row").ToList();
        ItemsList.ItemsSource = data;
    }
}
