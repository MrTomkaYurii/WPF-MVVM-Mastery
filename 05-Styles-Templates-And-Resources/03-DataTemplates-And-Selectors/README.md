# DataTemplates and TemplateSelectors

> Поліморфне відображення різнорідних об'єктів у списку за допомогою `DataTemplateSelector`.

```mermaid
flowchart TD
    Feed["Список постів (ObservableCollection&lt;FeedItem&gt;)"] --> Selector["FeedTemplateSelector"]
    Selector -->|Об'єкт TextPost| TemplateA["TextPostTemplate (Сіра плашка з автором)"]
    Selector -->|Об'єкт AlertPost| TemplateB["AlertPostTemplate (Червона рамка, статус 'КРИТИЧНО')"]
    TemplateA & TemplateB --> ListBox["ListBox рендерить кожен елемент своїм стилем"]
```

## 🎯 Чому присвячено проект
Коли колекція містить об'єкти різних класів-спадкоємців (наприклад, текстові повідомлення, системні алерти, вкладення), вони повинні виглядати по-різному.
Клас `DataTemplateSelector` аналізує тип елемента під час побудови візуального дерева та повертає відповідний шаблон `DataTemplate`.

## 🚀 Як запустити
```bash
dotnet run --project 03-DataTemplates-And-Selectors.csproj
```
