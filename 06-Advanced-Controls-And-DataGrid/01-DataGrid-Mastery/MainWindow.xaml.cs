using System.Collections.ObjectModel;
using System.Windows;
using DataGridMastery.Models;

namespace DataGridMastery;

public partial class MainWindow : Window
{
    public ObservableCollection<Order> Orders { get; } = new()
    {
        new Order { OrderId = 101, Customer = "Acme Corp", Total = 1250.00m, IsShipped = true, ShippingAddress = "124 Innovation Way, Tech Park, CA" },
        new Order { OrderId = 102, Customer = "CyberDyne Systems", Total = 4890.50m, IsShipped = false, ShippingAddress = "Building 4, Sector 7, Austin, TX" },
        new Order { OrderId = 103, Customer = "Wayne Enterprises", Total = 9320.00m, IsShipped = true, ShippingAddress = "1007 Mountain Drive, Gotham" }
    };

    public MainWindow()
    {
        InitializeComponent();
        OrdersGrid.ItemsSource = Orders;
    }
}
