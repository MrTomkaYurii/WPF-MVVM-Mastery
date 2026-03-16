using System.Windows;
namespace DialogServiceShowcase.Services;

public interface IDialogService
{
    bool Confirm(string title, string message);
}

public class WpfDialogService : IDialogService
{
    public bool Confirm(string title, string message) =>
        MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
}
