using System.Diagnostics;

namespace MyFirstMauiApp;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        LoginIn.Clicked += LoginButton_Clicked;
    }

    private string userName;
    private string password;

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Clicked!");
    }
}