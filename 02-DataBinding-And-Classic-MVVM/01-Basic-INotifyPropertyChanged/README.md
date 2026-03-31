# Basic INotifyPropertyChanged

> Класична реалізація сповіщень інтерфейсу про зміни даних у властивостях ViewModel.

```mermaid
sequenceDiagram
    participant UI as StudentView (UI)
    participant VM as StudentViewModel
    participant Student as Student Model (INPC)

    UI->>Student: Введення тексту в поле FirstName
    Student->>Student: Оновлення внутрішнього поля
    Student-->>UI: RaisePropertyChanged("FirstName")
    Student-->>UI: RaisePropertyChanged("FullName")
    UI->>UI: Оновлення прив'язаних TextBlock у вікні
```

## 🎯 Чому присвячено проект
Демонстрація фундаментального інтерфейсу `System.ComponentModel.INotifyPropertyChanged`. Без нього інтерфейс WPF не може дізнатися, коли змінні в пам'яті C# змінили своє значення.

### Розбір коду:
```csharp
public class Student : INotifyPropertyChanged
{
    private string firstname = string.Empty;
    public string FirstName
    {
        get => firstname;
        set
        {
            if (firstname != value)
            {
                firstname = value;
                RaisePropertyChanged(nameof(FirstName));
                RaisePropertyChanged(nameof(FullName)); // Похідна властивість оновлюється автоматично
            }
        }
    }
}
```

## 🚀 Як запустити
```bash
dotnet run --project MVVM_Example_01.csproj
```
