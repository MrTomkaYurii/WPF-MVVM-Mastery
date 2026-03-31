# ObservableValidator and DataAnnotations

> Професійна валідація форм у WPF за допомогою атрибутів `[Required]`, `[EmailAddress]`, `[Range]` та інтерфейсу `INotifyDataErrorInfo`.

```mermaid
flowchart TD
    User["Користувач вводить email: 'invalid-mail'"] --> VM["ViewModel : ObservableValidator"]
    VM --> Rule{"EmailAddressAttribute?"}
    Rule -->|Помилка| Error["Додавання до ErrorsContainer"]
    Error --> Event["ErrorsChanged?.Invoke()"]
    Event --> UI["XAML: Червона рамка та текст помилки під полем"]
```

## 🎯 Чому присвячено проект
`ObservableValidator` із `CommunityToolkit.Mvvm` поєднує стандартні атрибути валідації .NET із механізмом `INotifyDataErrorInfo` у WPF.
У проекті реалізовано кастомний `Validation.ErrorTemplate`, завдяки якому тексти помилок виводяться безпосередньо під відповідним полем введення.

## 🚀 Як запустити
```bash
dotnet run --project 03-ObservableValidator-And-Validation.csproj
```
