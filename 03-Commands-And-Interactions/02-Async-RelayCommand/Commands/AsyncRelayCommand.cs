using System.Windows.Input;

namespace AsyncRelayCommandShowcase.Commands;

public class AsyncRelayCommand : ICommand
{
    private readonly Func<CancellationToken, Task> _execute;
    private readonly Func<bool>? _canExecute;
    private bool _isExecuting;
    private CancellationTokenSource? _cts;

    public bool IsExecuting
    {
        get => _isExecuting;
        private set
        {
            _isExecuting = value;
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public AsyncRelayCommand(Func<CancellationToken, Task> execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => !IsExecuting && (_canExecute?.Invoke() ?? true);

    public async void Execute(object? parameter) => await ExecuteAsync();

    public async Task ExecuteAsync()
    {
        if (CanExecute(null))
        {
            try
            {
                IsExecuting = true;
                _cts = new CancellationTokenSource();
                await _execute(_cts.Token);
            }
            finally
            {
                IsExecuting = false;
                _cts?.Dispose();
                _cts = null;
            }
        }
    }

    public void Cancel() => _cts?.Cancel();

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
