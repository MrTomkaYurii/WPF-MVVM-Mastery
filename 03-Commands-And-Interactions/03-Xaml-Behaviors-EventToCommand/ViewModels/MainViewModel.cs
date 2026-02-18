using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace EventToCommandShowcase.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<string> Documents { get; } = new()
    {
        "Quarterly_Report_2026.pdf",
        "Architecture_Diagram_v2.png",
        "Production_Config_Release.json",
        "Database_Migration_Script.sql"
    };

    public string? SelectedDocument { get; set; }

    public ICommand ItemDoubleClickedCommand { get; }
    public ICommand WindowLoadedCommand { get; }

    public MainViewModel()
    {
        ItemDoubleClickedCommand = new SimpleCommand(param =>
        {
            if (param is string doc)
            {
                MessageBox.Show($"Opening document: {doc}", "EventToCommand Triggered", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        });

        WindowLoadedCommand = new SimpleCommand(_ =>
        {
            // EventToCommand on Loaded event
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public class SimpleCommand(Action<object?> execute) : ICommand
{
    public bool CanExecute(object? parameter) => true;
    public void Execute(object? parameter) => execute(parameter);
    public event EventHandler? CanExecuteChanged { add { } remove { } }
}
