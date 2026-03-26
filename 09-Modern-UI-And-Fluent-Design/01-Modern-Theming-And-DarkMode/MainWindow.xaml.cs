using System.Windows;

namespace ThemingShowcase;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void SetLight_Click(object sender, RoutedEventArgs e) => ApplyTheme("Themes/Light.xaml");
    private void SetDark_Click(object sender, RoutedEventArgs e) => ApplyTheme("Themes/Dark.xaml");

    private static void ApplyTheme(string uri)
    {
        var app = Application.Current;
        app.Resources.MergedDictionaries.Clear();
        app.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri(uri, UriKind.Relative) });
    }
}
