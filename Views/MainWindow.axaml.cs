using System;
using Avalonia.Controls;
using NoteGenerator.ViewModels;

namespace NoteGenerator.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel _vm;
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = _vm = new MainWindowViewModel();
    }
}