using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValueConvertersShowcase.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string _firstName = "Yurii";
    private string _lastName = "Tomka";
    private decimal _accountBalance = 1520.50m;
    private bool _isVipMember = true;
    private DateTime? _expiryDate = DateTime.Now.AddYears(1);

    public string FirstName { get => _firstName; set => SetField(ref _firstName, value); }
    public string LastName { get => _lastName; set => SetField(ref _lastName, value); }
    public decimal AccountBalance { get => _accountBalance; set => SetField(ref _accountBalance, value); }
    public bool IsVipMember { get => _isVipMember; set => SetField(ref _isVipMember, value); }
    public DateTime? ExpiryDate { get => _expiryDate; set => SetField(ref _expiryDate, value); }

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
