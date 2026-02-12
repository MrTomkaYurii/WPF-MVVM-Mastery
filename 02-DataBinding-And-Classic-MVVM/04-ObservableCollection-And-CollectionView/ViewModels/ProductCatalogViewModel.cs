using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using CollectionViewShowcase.Models;

namespace CollectionViewShowcase.ViewModels;

public class ProductCatalogViewModel : INotifyPropertyChanged
{
    private string _filterText = string.Empty;
    public ObservableCollection<Product> Products { get; }
    public ICollectionView ProductsView { get; }

    public string FilterText
    {
        get => _filterText;
        set
        {
            if (_filterText != value)
            {
                _filterText = value;
                OnPropertyChanged();
                ProductsView.Refresh();
            }
        }
    }

    public ProductCatalogViewModel()
    {
        Products = new ObservableCollection<Product>
        {
            new(1, "ThinkPad X1 Carbon", "Hardware", 1850m),
            new(2, "Apple MacBook Pro M3", "Hardware", 2200m),
            new(3, "Visual Studio Enterprise", "Software", 250m),
            new(4, "JetBrains All Products Pack", "Software", 289m),
            new(5, "Logitech MX Master 3S", "Peripherals", 99m),
            new(6, "Dell UltraSharp 27 4K", "Hardware", 540m),
            new(7, "Keychron K2 Wireless Keyboard", "Peripherals", 85m)
        };

        ProductsView = CollectionViewSource.GetDefaultView(Products);
        ProductsView.Filter = FilterProducts;
        ProductsView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        ProductsView.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
    }

    private bool FilterProducts(object item)
    {
        if (item is Product p)
        {
            return string.IsNullOrWhiteSpace(FilterText) ||
                   p.Name.Contains(FilterText, StringComparison.OrdinalIgnoreCase) ||
                   p.Category.Contains(FilterText, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
