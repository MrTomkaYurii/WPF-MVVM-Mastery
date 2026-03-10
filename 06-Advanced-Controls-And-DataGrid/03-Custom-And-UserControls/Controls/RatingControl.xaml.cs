using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ControlsShowcase.Controls;

public partial class RatingControl : UserControl
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(int), typeof(RatingControl),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public RatingControl()
    {
        InitializeComponent();
        UpdateStars();
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is RatingControl rc) rc.UpdateStars();
    }

    private void Star_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is TextBlock tb && int.TryParse(tb.Tag?.ToString(), out var rating))
        {
            Value = rating;
        }
    }

    private void UpdateStars()
    {
        Star1.Foreground = Value >= 1 ? Brushes.Goldenrod : Brushes.LightGray;
        Star2.Foreground = Value >= 2 ? Brushes.Goldenrod : Brushes.LightGray;
        Star3.Foreground = Value >= 3 ? Brushes.Goldenrod : Brushes.LightGray;
        Star4.Foreground = Value >= 4 ? Brushes.Goldenrod : Brushes.LightGray;
        Star5.Foreground = Value >= 5 ? Brushes.Goldenrod : Brushes.LightGray;
    }
}
