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
        Test();
        await Task.Delay(100);
        await Shell.Current.GoToAsync("..");
        Console.WriteLine("Total memory: " + GC.GetTotalMemory(false).ToString("N0"));
    }
    

    private void Test()
    {
        // Load the assembly containing the ContentPage class
        var assembly = typeof(Page).Assembly;

        // Get the type of the ContentPage class from the loaded assembly
        var type = assembly.GetType("Microsoft.Maui.Controls.ContentPage");
        if (type == null)
        {
            return;
        }

        // Retrieve the Appearing event information using reflection
        var eventInfo = type.GetEvent(nameof(Appearing), BindingFlags.Instance | BindingFlags.Public);
        if (eventInfo == null)
        {
            return;
        }

        // Get the field that stores the event's delegate
        var fieldInfo = type.BaseType.BaseType.GetField("Appearing", BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo == null)
        {
            return;
        }
        
        // Retrieve the delegate from the field
        var eventDelegate = fieldInfo.GetValue(this) as MulticastDelegate;
         if (eventDelegate == null)
        {
            return;
        }

        // Get the invocation list from the delegate
        var invocationList = eventDelegate.GetInvocationList();
        foreach (var handler in invocationList)
        {
            // Remove each handler from the event
            eventInfo.RemoveEventHandler(this, handler);
        }
    }
}
