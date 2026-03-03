using System.Collections.ObjectModel;
using System.Windows;
using DataTemplatesShowcase.Models;

namespace DataTemplatesShowcase;

public partial class MainWindow : Window
{
    public ObservableCollection<FeedItem> Items { get; } = new()
    {
        new TextPost("Yurii", DateTime.Now, "Welcome to the WPF Mastery course!"),
        new AlertPost("System Monitor", DateTime.Now, "CRITICAL", "High CPU load on worker node #3"),
        new TextPost("Alice", DateTime.Now, "Design templates are looking super clean.")
    };

    public MainWindow()
    {
        InitializeComponent();
        FeedListBox.ItemsSource = Items;
    }
}
