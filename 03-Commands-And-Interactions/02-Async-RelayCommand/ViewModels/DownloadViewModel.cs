using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AsyncRelayCommandShowcase.Commands;

namespace AsyncRelayCommandShowcase.ViewModels;

public class DownloadViewModel : INotifyPropertyChanged
{
    private int _progress;
    private string _status = "Ready";

    public int Progress { get => _progress; set => SetField(ref _progress, value); }
    public string Status { get => _status; set => SetField(ref _status, value); }

    public AsyncRelayCommand StartDownloadCommand { get; }
    public ICommand CancelCommand { get; }

    public DownloadViewModel()
    {
        StartDownloadCommand = new AsyncRelayCommand(DownloadDataAsync);
        CancelCommand = new RelayCommand(_ => StartDownloadCommand.Cancel(), _ => StartDownloadCommand.IsExecuting);
    }

    private async Task DownloadDataAsync(CancellationToken token)
    {
        Status = "Downloading dataset...";
        Progress = 0;

        for (int i = 1; i <= 100; i++)
        {
            if (token.IsCancellationRequested)
            {
                Status = "Operation cancelled by user.";
                return;
            }

            await Task.Delay(40, token);
            Progress = i;
            Status = $"Processing {i}%...";
        }

        Status = "Download completed successfully!";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(name);
        return true;
    }
}

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;
    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
    public void Execute(object? parameter) => _execute(parameter);
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
