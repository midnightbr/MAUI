namespace MyFirstMauiApp;

public partial class MainPage : ContentPage
{
    public const double MyFontSize = 15;

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


/**
 * O objetivo das extensões de marcação personalizadas é permitir que você lide com situações mais complexas, em vez do simples caso estático.
 * Por exemplo, talvez seja necessário alterar dinamicamente o tamanho da fonte com base no fator de forma do dispositivo.
 */
[ContentProperty("Member")]
public class StaticExtension : IMarkupExtension
{
    public string Member { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return MainPage.MyFontSize;
    }
}