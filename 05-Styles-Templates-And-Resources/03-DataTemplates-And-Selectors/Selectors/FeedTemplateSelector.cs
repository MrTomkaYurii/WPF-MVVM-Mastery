using System.Windows;
using System.Windows.Controls;
using DataTemplatesShowcase.Models;

namespace DataTemplatesShowcase.Selectors;

public class FeedTemplateSelector : DataTemplateSelector
{
    public DataTemplate? TextTemplate { get; set; }
    public DataTemplate? AlertTemplate { get; set; }

    public override DataTemplate? SelectTemplate(object item, DependencyObject container) =>
        item switch
        {
            AlertPost => AlertTemplate,
            TextPost => TextTemplate,
            _ => base.SelectTemplate(item, container)
        };
}
