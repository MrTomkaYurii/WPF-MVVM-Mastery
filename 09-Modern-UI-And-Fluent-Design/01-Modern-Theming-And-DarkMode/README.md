# Runtime Theme Switching and WindowChrome

> Гаряче перемикання світлої та темної теми на льоту та сучасні вікна без стандартних системних рамок за допомогою `WindowChrome`.

```mermaid
flowchart LR
    User["Клік 'Dark Mode'"] --> AppResources["Application.Current.Resources.MergedDictionaries"]
    AppResources --> Clear["Clear() &amp; Add('Themes/Dark.xaml')"]
    Clear --> Redraw["Всі DynamicResource (фони, шрифти) плавно оновлюють колір"]
```

## 🎯 Чому присвячено проект
- **Динамічна зміна теми**: використання `DynamicResource` замість `StaticResource` дозволяє на льоту замінити словник ресурсів без перезапуску програми.
- **`WindowChrome`**: прибирає застарілу системну рамку Windows, дозволяючи створити сучасний стиль Windows 11 Fluent Design.

## 🚀 Як запустити
```bash
dotnet run --project 01-Modern-Theming-And-DarkMode.csproj
```
