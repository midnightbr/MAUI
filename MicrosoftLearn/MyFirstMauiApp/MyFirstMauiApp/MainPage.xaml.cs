namespace MyFirstMauiApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private string _translateNumber;

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        _translateNumber = PhonewordTranslator.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(_translateNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + _translateNumber;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }

    private async void OnCall(object sender, EventArgs e)
    {
        if (await this.DisplayAlert("Dial a Number", $"Would you like to call {_translateNumber}?", "Yes", "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                {
                    PhoneDialer.Default.Open(_translateNumber);
                }
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }
        }
    }
}