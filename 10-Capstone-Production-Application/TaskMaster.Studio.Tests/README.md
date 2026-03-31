# TaskMaster Studio Automated Tests

> Комплект модульних тестів (Unit Tests) на базі `xUnit` та `FluentAssertions` для перевірки бізнес-логіки та команд ViewModel.

```mermaid
flowchart LR
    Test1["CreateTaskCommand_WhenTitleIsValid_ShouldAddTask()"] --> VM["MainViewModel"]
    Test2["DeleteTaskCommand_WhenTargetProvided_ShouldRemove()"] --> VM
    VM --> Assert["FluentAssertions: Count.Should().Be(initial + 1)"]
```

## 🎯 Чому присвячено проект
Показує, як правильно тестувати WPF-додатки без запуску графічного вікна:
- Перевірка виконання команд `vm.CreateTaskCommand.Execute(null)`.
- Перевірка реакції колекцій на додавання та видалення.
- Моніторинг очищення полів після успішного збереження.

## 🚀 Як запустити тести
```bash
dotnet test TaskMaster.Studio.Tests.csproj
```
