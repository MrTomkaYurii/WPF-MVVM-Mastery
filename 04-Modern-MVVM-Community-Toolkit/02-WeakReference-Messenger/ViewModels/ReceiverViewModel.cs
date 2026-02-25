using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MessengerShowcase.Messages;

namespace MessengerShowcase.ViewModels;

public partial class ReceiverViewModel : ObservableObject, IRecipient<NotificationMessage>
{
    public ObservableCollection<string> ReceivedMessages { get; } = new();

    public ReceiverViewModel()
    {
        WeakReferenceMessenger.Default.Register<NotificationMessage>(this);
    }

    public void Receive(NotificationMessage message)
    {
        ReceivedMessages.Insert(0, $"[{message.Timestamp:HH:mm:ss}] {message.Title}: {message.Content}");
    }
}
