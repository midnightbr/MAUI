using System.Diagnostics;

namespace MyFirstMauiApp;

public partial class Login : ContentPage
{
    public const double MyFontSize = 20;

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


/**
 * O campoMyFontSizedeve ser um membro da classeMainPagepara permitir que ele seja referenciado no método ProvideValue à sua maneira.
 * As boas práticas implicam que, neste caso, a variável também deve ser uma constante. O valor é.static, const ou static.
 * O método ProvideValue também pode fazer ajustes no valor retornado, dependendo da orientação e do fator de forma do dispositivo.
 */
// Criando uma extensão de marcação
public class GlobalFontSizeExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return Login.MyFontSize;
    }
}