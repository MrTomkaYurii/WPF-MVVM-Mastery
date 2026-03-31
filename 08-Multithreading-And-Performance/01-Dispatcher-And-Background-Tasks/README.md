# Dispatcher and IProgress Multithreading

> Безпечна взаємодія фонових обчислень із головним потоком інтерфейсу (UI Thread).

```mermaid
flowchart TD
    UIThread["UI Thread (Dispatcher)<br/>Оновлює вікно, реагує на кліки (60 FPS)"]
    WorkerThread["Background Thread (Task.Run)<br/>Обчислює важкі дані, цикл 1..100"]

    UIThread -->|Task.Run| WorkerThread
    WorkerThread -->|progress.Report(percent)| IProgress["Progress&lt;int&gt;"]
    IProgress -->|Автоматичний маршалінг у UI| UIThread
```

## 🎯 Чому присвячено проект
Будь-яка важка операція (запит до БД, парсинг файлу, математичний розрахунок), виконана у головному потоці, «заморожує» вікно програми.
Якщо ж спробувати оновити `ProgressBar.Value` з іншого потоку, виникне помилка `InvalidOperationException: The calling thread cannot access this object because a different thread owns it`.
Проект демонструє:
- Запуск фонової задачі через `Task.Run`.
- Безпечний звіт про прогрес через `Progress<T>`.

## 🚀 Як запустити
```bash
dotnet run --project 01-Dispatcher-And-Background-Tasks.csproj
```
