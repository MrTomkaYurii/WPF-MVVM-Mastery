# UI Virtualization for 50,000+ Items

> Високопродуктивна віртуалізація списків у WPF за допомогою `VirtualizingStackPanel`.

```mermaid
flowchart TD
    Dataset["50,000 елементів у пам'яті (ObservableCollection)"] --> Viewport["Вікно користувача (Поміщається лише 15 рядків)"]
    Viewport --> Virtualizer["VirtualizingStackPanel (VirtualizationMode='Recycling')"]
    Virtualizer --> Memory["Створюється лише ~20 візуальних контейнерів Border/TextBlock"]
    Memory --> Reuse["При скролі контейнери переприв'язуються (Recycled), пам'ять не росте"]
```

## 🎯 Чому присвячено проект
Якщо відобразити 50,000 рядків у звичайному `StackPanel`, WPF створить 50,000 складних UI-об'єктів, що призведе до зависання на кілька хвилин та споживання сотень мегабайт пам'яті.
`VirtualizingStackPanel.IsVirtualizing="True"` та режим `Recycling` миттєво рендерить мільйони записів з плавним скролом.

## 🚀 Як запустити
```bash
dotnet run --project 02-UI-Virtualization-And-Memory.csproj
```
