# ObservableCollection and CollectionView

> Робота зі списками: автоматичне оновлення інтерфейсу через `ObservableCollection<T>` та миттєва фільтрація, сортування і групування через `ICollectionView`.

```mermaid
flowchart TD
    Source["ObservableCollection&lt;Product&gt;<br/>(Незмінний список у пам'яті)"] --> View["ICollectionView (DefaultView)"]
    Filter["FilterText ('Apple')"] --> View
    View --> Sort["SortDescriptions (За ціною)"]
    View --> Group["GroupDescriptions (За категорією)"]
    View --> UI["ListView (Відображення відфільтрованих груп)"]
```

## 🎯 Чому присвячено проект
Поширена помилка початківців — при кожному введенні символу у поле пошуку робити LINQ-запит `Products.Where(...)` і перезаписувати всю колекцію.
Правильний WPF-підхід — використання **`ICollectionView`**:
- Вихідна колекція `ObservableCollection` залишається незмінною.
- Фільтр `ProductsView.Filter = FilterPredicate` миттєво приховує зайві елементи.
- `ProductsView.GroupDescriptions` дозволяє у XAML задати гарний `GroupStyle` із заголовками категорій.

## 🚀 Як запустити
```bash
dotnet run --project 04-ObservableCollection-And-CollectionView.csproj
```
