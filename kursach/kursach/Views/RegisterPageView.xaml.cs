using kursach.ViewModels;

namespace kursach.Views;

public partial class RegisterPageView : ContentPage
{
	public RegisterPageView(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;
#if WINDOWS
        border.WidthRequest = 450;
#endif
    }
}