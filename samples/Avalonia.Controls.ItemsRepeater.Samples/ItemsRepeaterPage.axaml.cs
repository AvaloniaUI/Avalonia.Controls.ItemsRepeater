using System;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;

namespace Avalonia.Controls.Samples;

public partial class ItemsRepeaterPage : UserControl
{
    private readonly ItemsRepeaterPageViewModel _viewModel;
    private int _selectedIndex;
    private Random _random = new Random(0);

    public ItemsRepeaterPage()
    {
        this.InitializeComponent();
        repeater.PointerPressed += RepeaterClick;
        repeater.KeyDown += RepeaterOnKeyDown;
        scrollToLast.Click += scrollToLast_Click;
        scrollToRandom.Click += scrollToRandom_Click;
        scrollToSelected.Click += scrollToSelected_Click;
        DataContext = _viewModel = new ItemsRepeaterPageViewModel();
    }

    public void OnSelectTemplateKey(object sender, SelectTemplateEventArgs e)
    {
        if (e.DataContext is ItemsRepeaterPageViewModelItem item)
        {
            e.TemplateKey = (item.Index % 2 == 0) ? "even" : "odd";
        }
    }

    private void LayoutChanged(object sender, SelectionChangedEventArgs e)
    {
        if (repeater == null)
        {
            return;
        }

        var comboBox = (ComboBox)sender;

        switch (comboBox.SelectedIndex)
        {
            case 0:
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                repeater.Layout = new StackLayout { Orientation = Orientation.Vertical };
                break;
            case 1:
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                repeater.Layout = new StackLayout { Orientation = Orientation.Horizontal };
                break;
            case 2:
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                repeater.Layout = new UniformGridLayout
                {
                    Orientation = Orientation.Vertical,
                    MinItemWidth = 200,
                    MinItemHeight = 200,
                };
                break;
            case 3:
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                repeater.Layout = new UniformGridLayout
                {
                    Orientation = Orientation.Horizontal,
                    MinItemWidth = 200,
                    MinItemHeight = 200,
                };
                break;
            case 4:
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                repeater.Layout = new WrapLayout
                {
                    Orientation = Orientation.Vertical,
                    HorizontalSpacing = 20,
                    VerticalSpacing = 20
                };
                break;
            case 5:
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                repeater.Layout = new WrapLayout
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalSpacing = 20,
                    VerticalSpacing = 20
                };
                break;
        }
    }

    private void ScrollTo(int index)
    {
        System.Diagnostics.Debug.WriteLine("Scroll to " + index);
        var element = repeater.GetOrCreateElement(index);
        UpdateLayout();
        element.BringIntoView();
    }

    private void RepeaterClick(object? sender, PointerPressedEventArgs e)
    {
        if ((e.Source as TextBlock)?.DataContext is ItemsRepeaterPageViewModelItem item)
        {
            _viewModel.SelectedItem = item;
            _selectedIndex = _viewModel.Items.IndexOf(item);
        }
    }

    private void RepeaterOnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.F5)
        {
            _viewModel.ResetItems();
        }
    }

    private void scrollToLast_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ScrollTo(_viewModel.Items.Count - 1);
    }

    private void scrollToRandom_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ScrollTo(_random.Next(_viewModel.Items.Count - 1));
    }

    private void scrollToSelected_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ScrollTo(_selectedIndex);
    }
}
