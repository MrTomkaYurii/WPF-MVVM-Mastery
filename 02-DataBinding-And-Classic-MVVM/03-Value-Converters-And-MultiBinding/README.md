# Value Converters and MultiBinding

> Трансформація даних між джерелом (ViewModel) та споживачем (View) за допомогою `IValueConverter` та `IMultiValueConverter`.

```mermaid
flowchart TD
    VM["ViewModel Property<br/>(AccountBalance = -150.00m)"] --> Conv["BalanceToColorConverter<br/>(IValueConverter)"]
    Conv -->|Баланс &lt; 0| Red["Brushes.Crimson"]
    Conv -->|Баланс &gt;= 0| Green["Brushes.ForestGreen"]
    Red --> View["Foreground у TextBlock"]
    
    VM1["FirstName: Yurii"] & VM2["LastName: Tomka"] --> MultiConv["FullNameMultiConverter<br/>(IMultiValueConverter)"]
    MultiConv --> FullName["Вивід: 'Tomka, Yurii'"]
```

## 🎯 Чому присвячено проект
Часто тип даних у ViewModel не відповідає типу, який очікує контрол у XAML (наприклад, `bool` треба перетворити у `Visibility`, або числове значення балансу у колір `Brush`).

### Реалізовані конвертери:
1. **`BoolToVisibilityConverter`**: замінює `true` $	o$ `Visible`, `false` $	o$ `Collapsed`.
2. **`BalanceToColorConverter`**: динамічно підсвічує від'ємний баланс червоним, а позитивний — зеленим кольором.
3. **`FullNameMultiConverter`**: приймає масив значень (`object[] values`) від `<MultiBinding>` і збирає повне ім'я.

## 🚀 Як запустити
```bash
dotnet run --project 03-Value-Converters-And-MultiBinding.csproj
```
