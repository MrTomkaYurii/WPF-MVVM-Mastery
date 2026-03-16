using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NavigationShowcase.ViewModels;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public class HomeViewModel : ViewModelBase { public string Message => "🏠 Welcome to Home Dashboard"; }
public class SettingsViewModel : ViewModelBase { public string Message => "⚙️ Application Settings"; }
public class ReportsViewModel : ViewModelBase { public string Message => "📊 Analytics and Reports"; }

public class MainNavigationViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set { _currentViewModel = value; OnPropertyChanged(); }
    }

    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateSettingsCommand { get; }
    public ICommand NavigateReportsCommand { get; }

    public MainNavigationViewModel()
    {
        var home = new HomeViewModel();
        var settings = new SettingsViewModel();
        var reports = new ReportsViewModel();

        _currentViewModel = home;

        NavigateHomeCommand = new SimpleCommand(_ => CurrentViewModel = home);
        NavigateSettingsCommand = new SimpleCommand(_ => CurrentViewModel = settings);
        NavigateReportsCommand = new SimpleCommand(_ => CurrentViewModel = reports);
    }
}

public class SimpleCommand(Action<object?> execute) : ICommand
{
    public bool CanExecute(object? parameter) => true;
    public void Execute(object? parameter) => execute(parameter);
    public event EventHandler? CanExecuteChanged { add { } remove { } }
}
