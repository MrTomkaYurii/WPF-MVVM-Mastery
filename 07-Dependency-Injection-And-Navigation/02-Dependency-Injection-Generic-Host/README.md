# Dependency Injection with Generic Host

> Сучасне впровадження залежностей у WPF через офіційну бібліотеку `Microsoft.Extensions.Hosting`.

```mermaid
flowchart TD
    App["App.xaml.cs (OnStartup)"] --> Builder["Host.CreateDefaultBuilder()"]
    Builder --> Services["ConfigureServices:<br/>- AddSingleton&lt;IUserService, UserService&gt;()<br/>- AddTransient&lt;MainViewModel&gt;()<br/>- AddSingleton&lt;MainWindow&gt;()"]
    Services --> Resolve["host.Services.GetRequiredService&lt;MainWindow&gt;()"]
    Resolve --> Show["mainWindow.Show()"]
```

## 🎯 Чому присвячено проект
Показує правильну організацію життєвого циклу WPF-додатку за стандартами бекенду .NET:
- Старт хоста через `await _host.StartAsync()` в `OnStartup`.
- Конструкторне впровадження залежностей: `MainViewModel(IUserService userService)`.
- Graceful shutdown у методі `OnExit`.

## 🚀 Як запустити
```bash
dotnet run --project 02-Dependency-Injection-Generic-Host.csproj
```
