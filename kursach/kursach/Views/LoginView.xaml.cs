using Acr.UserDialogs;
using kursach.ViewModels;

namespace kursach.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
#if WINDOWS
        Border.WidthRequest = 450;
#endif
    }
}