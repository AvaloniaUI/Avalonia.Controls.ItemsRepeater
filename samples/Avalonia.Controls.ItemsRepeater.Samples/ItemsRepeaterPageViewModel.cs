﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Avalonia.Controls.Samples;

public class ItemsRepeaterPageViewModel : INotifyPropertyChanged
{
    private int _newItemIndex = 1;
    private int _newGenerationIndex = 0;
    private ObservableCollection<ItemsRepeaterPageViewModelItem> _items;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ItemsRepeaterPageViewModel()
    {
        _items = CreateItems();
    }

    public ObservableCollection<ItemsRepeaterPageViewModelItem> Items
    {
        get => _items;
        set
        {
            if (_items != value)
            {
                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }
    }

    public ItemsRepeaterPageViewModelItem? SelectedItem { get; set; }

    public void AddItem()
    {
        var index = SelectedItem != null ? Items.IndexOf(SelectedItem) : -1;
        Items.Insert(index + 1, new ItemsRepeaterPageViewModelItem(index + 1, $"New Item {_newItemIndex++}"));
    }

    public void RemoveItem()
    {
        if (SelectedItem is not null)
        {
            Items.Remove(SelectedItem);
            SelectedItem = null;
        }
        else if (Items.Count > 0)
        {
            Items.RemoveAt(Items.Count - 1);
        }
    }

    public void RandomizeHeights()
    {
        var random = new Random();

        foreach (var i in Items)
        {
            i.Height = random.Next(240) + 10;
        }
    }

    public void ResetItems()
    {
        Items = CreateItems();
    }

    private ObservableCollection<ItemsRepeaterPageViewModelItem> CreateItems()
    {
        var suffix = _newGenerationIndex == 0 ? string.Empty : $"[{_newGenerationIndex.ToString()}]";

        _newGenerationIndex++;

        return new ObservableCollection<ItemsRepeaterPageViewModelItem>(
            Enumerable.Range(1, 100000).Select(i => new ItemsRepeaterPageViewModelItem(i, $"Item {i.ToString()} {suffix}")));
    }
}

public class ItemsRepeaterPageViewModelItem : INotifyPropertyChanged
{
    private double _height = double.NaN;

    public ItemsRepeaterPageViewModelItem(int index, string text)
    {
        Index = index;
        Text = text;
    }
    public int Index { get; }
    public string Text { get; }
        
    public double Height 
    {
        get => _height;
        set
        {
            if (_height != value)
            {
                _height = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Height)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
