namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
        
        MainPage = new AppShell();
    }
}