# WeakReferenceMessenger (Pub/Sub)

> Слабкопов'язана шина повідомлень між незалежними ViewModel без передачі прямих посилань та без витоків пам'яті.

```mermaid
flowchart TD
    Publisher["SenderViewModel (Видавець)"] -->|Send(NotificationMessage)| Bus["WeakReferenceMessenger.Default"]
    Bus -->|Слабке посилання| Sub1["ReceiverViewModel (Підписник 1)"]
    Bus -->|Слабке посилання| Sub2["DashboardViewModel (Підписник 2)"]
```

## 🎯 Чому присвячено проект
Коли один екран повинен повідомити інший про зміну даних (наприклад, користувач увійшов у систему або змінив налаштування), створення прямих зв'язків між ViewModel порушує архітектуру.
`WeakReferenceMessenger`:
- Підтримує слабкі посилання (`WeakReference`) — підписники автоматично збираються Garbage Collector, якщо вікно закрито.
- Реалізує інтерфейс `IRecipient<TMessage>`.

## 🚀 Як запустити
```bash
dotnet run --project 02-WeakReference-Messenger.csproj
```
