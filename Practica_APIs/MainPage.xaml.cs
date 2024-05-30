using Practica_APIs.MVVM.Views;

namespace Practica_APIs;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void GoToDashboard(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VDashboard());
    }
}