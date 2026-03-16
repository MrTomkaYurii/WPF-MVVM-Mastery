using GenericHostShowcase.Services;
namespace GenericHostShowcase.ViewModels;

public class MainViewModel(IUserService userService)
{
    public string Title => "WPF with Microsoft.Extensions.Hosting & DI (.NET 10)";
    public string CurrentUser => userService.GetCurrentUserName();
}
