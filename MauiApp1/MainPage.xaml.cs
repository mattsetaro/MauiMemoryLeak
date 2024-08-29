namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    protected override async void OnAppearing()
    {
        await Task.Delay(100);
        
        await Shell.Current.GoToAsync("/SecondPage");
        Console.WriteLine("Navigating to SecondPage");
    }
}