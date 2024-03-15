using System.Collections.ObjectModel;
using Avalonia.Headless.XUnit;
using Xunit;

namespace Avalonia.Controls.UnitTests;

public class ItemsRepeaterTests
{
    [AvaloniaFact]
    public void Can_Reassign_Items()
    {
        var target = new ItemsRepeater();
        target.ItemsSource = new ObservableCollection<string>();
        target.ItemsSource = new ObservableCollection<string>();
    }

    [AvaloniaFact]
    public void Can_Reassign_Items_To_Null()
    {
        var target = new ItemsRepeater();
        target.ItemsSource = new ObservableCollection<string>();
        target.ItemsSource = null;
    }
}
