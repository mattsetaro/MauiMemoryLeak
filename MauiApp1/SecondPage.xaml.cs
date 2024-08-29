using System.ComponentModel;
using System.Reflection;

namespace MauiApp1;

public partial class SecondPage : ContentPage
{
    public SecondPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await Task.Delay(100);
        await Shell.Current.GoToAsync("..");
        Console.WriteLine("Total memory: " + GC.GetTotalMemory(false).ToString("N0"));
    }
}
