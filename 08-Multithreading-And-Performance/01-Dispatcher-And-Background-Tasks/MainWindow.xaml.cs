using System.Windows;

namespace DispatcherShowcase;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private async void StartBtn_Click(object sender, RoutedEventArgs e)
    {
        StartBtn.IsEnabled = false;
        ProgBar.Value = 0;

        var progress = new Progress<int>(percent =>
        {
            ProgBar.Value = percent;
            StatusTxt.Text = $"Processed {percent}%...";
        });

        await Task.Run(() => DoHeavyWork(progress));

        StatusTxt.Text = "Background work completed safely!";
        StartBtn.IsEnabled = true;
    }

    private static void DoHeavyWork(IProgress<int> progress)
    {
        for (int i = 1; i <= 100; i++)
        {
            Thread.Sleep(30);
            progress.Report(i);
        }
    }
}
