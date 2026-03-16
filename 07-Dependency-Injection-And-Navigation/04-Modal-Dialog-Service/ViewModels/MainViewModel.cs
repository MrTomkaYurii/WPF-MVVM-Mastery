using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DialogServiceShowcase.Services;

namespace DialogServiceShowcase.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IDialogService _dialogService;
    private string _resultMessage = "Awaiting user confirmation...";

    public string ResultMessage
    {
        get => _resultMessage;
        set { _resultMessage = value; OnPropertyChanged(); }
    }

    public ICommand DeleteRecordCommand { get; }

    public MainViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
        DeleteRecordCommand = new SimpleCommand(_ =>
        {
            var confirmed = _dialogService.Confirm("Critical Action", "Are you sure you want to delete this database entry?");
            ResultMessage = confirmed ? "Entry deleted successfully." : "Deletion cancelled by user.";
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
