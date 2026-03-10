using System.Collections.ObjectModel;
using System.Windows;
using HierarchicalTreeViewShowcase.Models;

namespace HierarchicalTreeViewShowcase;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var root = new DirectoryItem("Source Repository")
        {
            Children =
            {
                new DirectoryItem("src")
                {
                    Children =
                    {
                        new DirectoryItem("Controllers"),
                        new DirectoryItem("Models"),
                        new DirectoryItem("Views")
                    }
                },
                new DirectoryItem("tests"),
                new DirectoryItem("docs")
            }
        };

        FolderTree.ItemsSource = new ObservableCollection<DirectoryItem> { root };
    }
}
