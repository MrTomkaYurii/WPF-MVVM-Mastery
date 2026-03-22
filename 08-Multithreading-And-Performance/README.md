# 08. Multithreading and Performance

> Багатопотоковість, синхронізація з UI-потоком та висока продуктивність: взаємодія через `Dispatcher` та `IProgress<T>`, віртуалізація інтерфейсу `VirtualizingStackPanel` для роботи з 50,000+ записами.

```mermaid
sequenceDiagram
    autonumber
    participant UI as UI Thread (Dispatcher)
    participant Worker as Background Task (Task.Run)
    participant Progress as IProgress Report

    UI->>Worker: Запуск фонового розрахунку
    Worker->>Worker: Обробка важких даних у фоні
    Worker->>Progress: progress.Report(percent)
    Progress-->>UI: Безпечне оновлення ProgressBar у потоці інтерфейсу
    Worker-->>UI: Завершення задачі
```

---

## 📂 Проекти модуля

### 1. `01-Dispatcher-And-Background-Tasks`
* Робота важких задач у фоновому потоці через `Task.Run`.
* Безпечна трансляція стану у потік інтерфейсу через `Progress<int>` без блокування вікна.
* Робота з `Dispatcher.InvokeAsync` та пріоритетами черги повідомлень.

### 2. `02-UI-Virtualization-And-Memory`
* Список на **50,000 записів**.
* Налаштування віртуалізації:
  * `VirtualizingStackPanel.IsVirtualizing="True"`
  * `VirtualizingStackPanel.VirtualizationMode="Recycling"`
  * `ScrollViewer.IsDeferredScrollingEnabled="True"`
* Створення візуальних елементів тільки для тих рядків, які безпосередньо відображаються на екрані, що знижує споживання пам'яті у десятки разів.
