using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityToolkitBasics.ViewModels;

public partial class CounterViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(StatusMessage))]
    private int _count = 0;

    [ObservableProperty]
    private string _userName = "Senior Developer";

    public string StatusMessage => $"Current value is: {Count} ({(Count % 2 == 0 ? "Even" : "Odd")})";

    [RelayCommand]
    private void Increment() => Count++;

    [RelayCommand]
    private void Decrement()
    {
        if (Count > 0) Count--;
    }

    [RelayCommand]
    private void Reset() => Count = 0;
}
