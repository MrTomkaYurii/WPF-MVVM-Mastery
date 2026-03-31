# Async RelayCommand with Cancellation

> Безпечне виконання тривалих фонових операцій із запобіганням подвійним клікам та підтримкою скасування через `CancellationToken`.

```mermaid
sequenceDiagram
    actor User as Користувач
    participant UI as Кнопка "Start Task"
    participant Cmd as AsyncRelayCommand
    participant Task as Фоновий процес (DownloadDataAsync)

    User->>UI: Клік на кнопку
    UI->>Cmd: ExecuteAsync()
    Cmd->>Cmd: IsExecuting = true
    Cmd-->>UI: Кнопка блокується (CanExecute = false)
    Cmd->>Task: Виконання задачі (передано CancellationToken)
    Task-->>UI: Оновлення Progress (0..100%)
    Task->>Cmd: Завершення роботи
    Cmd->>Cmd: IsExecuting = false
    Cmd-->>UI: Кнопка знову активна
```

## 🎯 Чому присвячено проект
Стандартний `ICommand.Execute(object)` є синхронним методом (`void`). Якщо викликати `await` всередині `async void`, неможливо контролювати статус виконання операції.
`AsyncRelayCommand`:
1. Встановлює `IsExecuting = true`, блокуючи кнопку на час запиту.
2. Створює `CancellationTokenSource`, дозволяючи окремій кнопці "Cancel" скасувати операцію в будь-який момент.
3. Гарантує виконання блоку `finally` для очищення ресурсів.

## 🚀 Як запустити
```bash
dotnet run --project 02-Async-RelayCommand.csproj
```
