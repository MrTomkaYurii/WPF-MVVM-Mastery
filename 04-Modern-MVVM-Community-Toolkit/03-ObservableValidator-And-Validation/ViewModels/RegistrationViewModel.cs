using System.ComponentModel.DataAnnotations;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ValidationShowcase.ViewModels;

public partial class RegistrationViewModel : ObservableValidator
{
    [ObservableProperty]
    [Required(ErrorMessage = "Username is mandatory")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    private string _username = string.Empty;

    [ObservableProperty]
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    private string _email = string.Empty;

    [ObservableProperty]
    [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
    private int _age = 25;

    [RelayCommand]
    private void Register()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            MessageBox.Show("Please correct validation errors before proceeding.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
            MessageBox.Show($"User {Username} registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
