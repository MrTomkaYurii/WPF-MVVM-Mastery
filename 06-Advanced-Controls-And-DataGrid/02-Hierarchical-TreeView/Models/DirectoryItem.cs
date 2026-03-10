using System.Collections.ObjectModel;
namespace HierarchicalTreeViewShowcase.Models;

public class DirectoryItem(string name)
{
    public string Name { get; set; } = name;
    public ObservableCollection<DirectoryItem> Children { get; set; } = new();
}
