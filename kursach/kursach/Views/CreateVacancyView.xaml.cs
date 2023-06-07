using kursach.ViewModels;
using kursach.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace kursach.Views;


public partial class CreateVacancyView : ContentPage
{
    public CreateVacancyViewModel _viewModel;
    public CreateVacancyView(CreateVacancyViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    async void BackToMyVacancies(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(BasketView)}", true);
    }


}
