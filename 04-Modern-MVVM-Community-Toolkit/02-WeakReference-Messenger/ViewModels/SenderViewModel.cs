using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessengerShowcase.Messages;

namespace MessengerShowcase.ViewModels;

public partial class SenderViewModel : ObservableObject
{
    [ObservableProperty]
    private string _notificationText = "New production deployment completed!";

    [RelayCommand]
    private void SendMessage()
    {
        WeakReferenceMessenger.Default.Send(new NotificationMessage("System Alert", NotificationText, DateTime.Now));
    }
}
