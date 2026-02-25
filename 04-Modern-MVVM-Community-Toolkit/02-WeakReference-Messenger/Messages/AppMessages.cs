using CommunityToolkit.Mvvm.Messaging.Messages;
namespace MessengerShowcase.Messages;

public record NotificationMessage(string Title, string Content, DateTime Timestamp);
