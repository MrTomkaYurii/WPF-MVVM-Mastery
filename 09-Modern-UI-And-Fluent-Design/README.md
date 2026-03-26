# 09. Modern UI and Fluent Design

> Сучасні інтерфейси та стилізація: гаряче перемикання світлої та темної теми оформлення без перезапуску програми та створення сучасних безрамкових вікон за допомогою `WindowChrome`.

```mermaid
stateDiagram-v2
    [*] --> LightTheme: Запуск додатку
    LightTheme --> DarkTheme: Натиснуто "Dark Mode" (Підміна MergedDictionaries)
    DarkTheme --> LightTheme: Натиснуто "Light Mode" (Підміна MergedDictionaries)
```

---

## 📂 Проекти модуля

### 1. `01-Modern-Theming-And-DarkMode`
* Динамічна заміна ресурсів у `Application.Current.Resources.MergedDictionaries`.
* Використання `WindowChrome` для стилізації системного заголовка та інтеграції елементів керування у заголовок вікна.
